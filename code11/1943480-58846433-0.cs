    public async Task<(string sourceFolderPath, string destinationFolderPath)> CropBlackBorderOfAnImage(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName);
        var newFileName = Guid.NewGuid().ToString();//Create a new Name for the file due to security reasons.
        var fileNameSource = newFileName + extension;
        var sourceFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images\\Source", fileNameSource);
        var fileNameDestination = newFileName + "Result" + extension;
        var destinationFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Images\\Destination", fileNameDestination);
        await SaveImageForProcessing(file, sourceFolderPath);
        await _imageCropBlackBroderService.CropBlackBroderOfAnImageAsync(sourceFolderPath, destinationFolderPath);
        return (sourceFolderPath, destinationFolderPath);
    }
    private async Task SaveImageForProcessing(IFormFile file, string path)
    {
        using (var bits = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(bits);
        }
    }
