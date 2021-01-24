    var mediaBag = new ConcurrentBag<MediaDto>();
    Task<byte[]>[] tasks = mediaList.Select(media => blobStorageService.ReadMedia(media.BlobID, Enums.MediaType.Image)).ToArray();
    await Task.WhenAll(tasks);
    Parallel.ForEach(imgBytes, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
        bytes =>
        {
            var fileContent = Convert.ToBase64String(imgBytes);
            var image = new MediaDto()
            {
                ImageId = media.MediaID,
                Title = media.Title,
                Description = media.Description,
                ImageContent = fileContent
            };
            mediaBag.Add(image);
        });
    return mediaBag.ToList();
