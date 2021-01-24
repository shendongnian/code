        public async Task<IActionResult> UploadImageAsync([FromBody] ImageUploadRequest imageRequest)
        {
            if (string.IsNullOrEmpty(imageRequest?.Base64))
            {
                return BadRequest();
            }
            var tokens = imageRequest.Base64.Split(',');
            var ctype = tokens[0].Replace("data:", "");
            var base64 = tokens[1];
            var content = Convert.FromBase64String(base64);
            // Upload photo to storage...
            var blobUri = await UploadImageToStorage(content);
            // Then create a Document in CosmosDb to notify our Function
            var identifier = await UploadDocument(blobUri, imageRequest.Name ?? "Bob");
            return Ok(identifier);
        }
        private async Task<Guid> UploadDocument(Uri uri, string imageName)
        {
            var endpoint = new Uri(_settings.ImageConfig.CosmosUri);
            var auth = _settings.ImageConfig.CosmosKey;
            var client = new DocumentClient(endpoint, auth);
            var identifier = Guid.NewGuid();
            await client.CreateDatabaseIfNotExistsAsync(new Database() { Id = dbName });
            await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(dbName),
                new DocumentCollection { Id = colName });
            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(dbName, colName),
                new ImageDocument
                {
                    Id = identifier,
                    IsApproved = null,
                    PetName = petName,
                    MediaUrl = uri.ToString(),
                    Created = DateTime.UtcNow
                });
            return identifier;
        }
        private async Task<Uri> UploadImageToStorage(byte[] content)
        {
            var storageName = _settings.PetsConfig.BlobName;
            var auth = _settings.PetsConfig.BlobKey;
            var uploader = new PhotoUploader(storageName, auth);
            var blob = await uploader.UploadPetPhoto(content);
            return blob.Uri;
        }
