        [HttpGet]
        public async Task<IActionResult> GetProfileImage(string url)
        {
            var telemetry = new TelemetryClient();
            try
            {
                //Initalize configuration settings
                var accountName = ConfigurationManager.AppSettings["storage:account:name"];
                var accountKey = ConfigurationManager.AppSettings["storage:account:key"];
                var profilepicturecontainername = ConfigurationManager.AppSettings["storage:account:profilepicscontainername"];
                //Instance objects needed to store the files
                var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer imagesContainer = blobClient.GetContainerReference(profilepicturecontainername);
                //Gets blob reference
                var cloudBlob = await blobClient.GetBlobReferenceFromServerAsync(new Uri(url));
                //Check if it exists
                var cloudBlobExists = await cloudBlob.ExistsAsync();
                //Opens memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    cloudBlob.DownloadToStream(ms);
                    
                    return File(ms, "application/octet-stream");
                }
            }
            catch (Exception ex)
            {
                string guid = Guid.NewGuid().ToString();
                var dt = new Dictionary<string, string>
                {
                    { "Error Lulo: ", guid }
                };
                telemetry.TrackException(ex, dt);
                return BadRequest("Error Lulo: " + guid);
            }
        }
