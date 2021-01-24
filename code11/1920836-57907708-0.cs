    var mediaBag = new ConcurrentBag<MediaDto>();
            IEnumerable<Task> mediaTasks = mediaList.Select(async m =>
            {
                var imgBytes = await this.blobStorageService.ReadMedia(m.BlobID, Enums.MediaType.Image);
                var fileContent = Convert.ToBase64String(imgBytes);
                var image = new MediaDto()
                {
                    ImageId = m.MediaID,
                    Title = m.Title,
                    Description = m.Description,
                    ImageContent = fileContent
                };
                mediaBag.Add(image);
            });
            await Task.WhenAll(mediaTasks);
            return mediaBag.ToList();
