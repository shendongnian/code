    [HttpPost]
        public JsonResult UploadApi(String video_url)
        {
            var id = 1;
            WebClient client = new WebClient();
            var videoStream = new MemoryStream(client.DownloadData(video_url));
            var container = CloudStorageAccount.Parse(mediaServiceStorageConnectionString).CreateCloudBlobClient().GetContainerReference(mediaServiceStorageContainerReference);
            container.CreateIfNotExists();
            var fileName = Path.GetFileName(video_url);
            var fileToUpload = new CloudFile()
            {
                BlockCount = 1,
                FileName = fileName,
                Size = videoStream.Length,
                BlockBlob = container.GetBlockBlobReference(fileName),
                StartTime = DateTime.Now,
                IsUploadCompleted = false,
                UploadStatusMessage = string.Empty
            };
            Session.Add("CurrentFile", fileToUpload);
            byte[] chunk = new byte[videoStream.Length];
            //request.InputStream.Read(chunk, 0, Convert.ToInt32(request.Length));
            //JsonResult returnData = null;
            string fileSession = "CurrentFile";
            CloudFile model = (CloudFile)Session[fileSession];    
            var blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    string.Format(CultureInfo.InvariantCulture, "{0:D4}", id)));
            try
            {
                model.BlockBlob.PutBlock(
                    blockId,
                    videoStream, null, null,
                    new BlobRequestOptions()
                    {
                        RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(10), 3)
                    },
                    null);
            }
            catch (StorageException e)
            {
                model.IsUploadCompleted = true;
                model.UploadStatusMessage = "Failed to Upload file. Exception - " + e.Message;
                return Json(new { error = true, isLastBlock = false, message = model.UploadStatusMessage });
            }
            var blockList = Enumerable.Range(1, (int)model.BlockCount).ToList<int>().ConvertAll(rangeElement => Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0:D4}", rangeElement))));
            model.BlockBlob.PutBlockList(blockList);
            var duration = DateTime.Now - model.StartTime;
            float fileSizeInKb = model.Size / 1024;
            string fileSizeMessage = fileSizeInKb > 1024 ? string.Concat((fileSizeInKb / 1024).ToString(CultureInfo.CurrentCulture), " MB") : string.Concat(fileSizeInKb.ToString(CultureInfo.CurrentCulture), " KB");
            model.UploadStatusMessage = string.Format(CultureInfo.CurrentCulture, "File of size {0} took {1} seconds to upload.", fileSizeMessage, duration.TotalSeconds);
            IAsset mediaServiceAsset = CreateMediaAsset(model);
            model.AssetId = mediaServiceAsset.Id;
            // Note: You need atleast 1 reserve streaming unit for dynamic packaging of encoded media. If you don't have that, you can't see video file playing.
            var assetId = model.AssetId;
            IAsset inputAsset = GetAssetById(assetId);
            string token = string.Empty;
            string uploadFileOriginalName = string.Empty;
            ////// Without preset (say default preset), works very well
            //IJob job = context.Jobs.CreateWithSingleTask(MediaProcessorNames.AzureMediaEncoder,
            //    MediaEncoderTaskPresetStrings.H264AdaptiveBitrateMP4Set720p,
            //    inputAsset,
            //    "UploadedVideo-" + Guid.NewGuid().ToString().ToLower() + "-Adaptive-Bitrate-MP4",
            //    AssetCreationOptions.None);
            //job.Submit();
            //IAsset encodedOutputAsset = job.OutputMediaAssets[0];
            //// XML Preset
            IJob job = context.Jobs.Create(inputAsset.Name);
            IMediaProcessor processor = GetLatestMediaProcessorByName("Media Encoder Standard");
            string configuration = System.IO.File.ReadAllText(HttpContext.Server.MapPath("~/MediaServicesCustomPreset.xml"));
            ITask task = job.Tasks.AddNew(inputAsset.Name + "- encoding task", processor, configuration, TaskOptions.None);
            task.InputAssets.Add(inputAsset);
            task.OutputAssets.AddNew(inputAsset.Name + "-Adaptive-Bitrate-MP4", AssetCreationOptions.None);
            job.Submit();
            IAsset encodedAsset = job.OutputMediaAssets[0];
            // process policy & encryption
            ProcessPolicyAndEncryption(encodedAsset);
            // Get file name
            uploadFileOriginalName = model.FileName;
            // Generate Streaming URL
            string smoothStreamingUri = GetStreamingOriginLocator(encodedAsset, uploadFileOriginalName);
            // add jobid and output asset id in database
            AzureMediaServicesContext db = new AzureMediaServicesContext();
            var video = new Video();
            video.RowAssetId = assetId;
            video.EncodingJobId = job.Id;
            video.EncodedAssetId = encodedAsset.Id;
            video.LocatorUri = smoothStreamingUri;
            video.IsEncrypted = useAESRestriction;
            db.Videos.Add(video);
            db.SaveChanges();
            if (useAESRestriction)
            {
                token = AzureMediaAsset.GetTestToken(encodedAsset.Id, encodedAsset);
            }
            // Remove session
            Session.Remove("CurrentFile");
            // return success response
            return Json(new
            {
                error = false,
                message = "Congratulations! Video is uploaded and pipelined for encoding, check console log for after encoding playback details.",
                assetId = assetId,
                jobId = job.Id,
                locator = smoothStreamingUri,
                encrypted = useAESRestriction,
                token = token
            });
            //if (id == model.BlockCount){CommitAllChunks(model);}
            //return Json(new { error = false, isLastBlock = false, message = string.Empty, filename = fileName,filesize = videoStream.Length });
        }
