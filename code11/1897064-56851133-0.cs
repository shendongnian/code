    async Task<int> UploadPicturesAsync(List<Image> imageList, IProgress<string> progress)
    {
            int totalCount = imageList.Count;
            int processCount = await Task.Run<int>(() =>
            {
                foreach (var image in imageList)
                {
                    //await the processing and uploading logic here
                    int processed = await UploadAndProcessAsync(image);
                    if (progress != null)
                    {
                        var message=$"{(tempCount * 100 / totalCount)}";
                        progress.Report(message);
                    }
                    tempCount++;
                }
                return tempCount;
            });
            return processCount;
    }
