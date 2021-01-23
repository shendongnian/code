                var writerlock = new object();
                using (var tu = new TransferUtility(amazonS3Client, tuconfig))
                {
                    var turequest = new TransferUtilityUploadRequest()
                        .WithBucketName(bucket)
                        .WithFilePath(file)
                        .WithKey(Path.GetFileName(file))
                        .WithStorageClass(S3StorageClass.ReducedRedundancy)
                        .WithPartSize(5 * 1024 * 1024)
                        .WithAutoCloseStream(true)
                        .WithCannedACL(S3CannedACL.PublicRead);
                    tuconfig.NumberOfUploadThreads = Environment.ProcessorCount - 1;
                    // show progress information if not running batch
                    if (interactive)
                    {
                        turequest.UploadProgressEvent += (s, e) =>
                                                          {
                                                              lock (writerlock)
                                                              {
                                                                  ... our progress routine ...
                                                              }
                                                          };
                    }
                    tu.Upload(turequest);
                }
