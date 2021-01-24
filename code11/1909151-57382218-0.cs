C#
private byte[] ConvertImageToByteArray(IFormFile image)
{
    byte[] result = null;
    // filestream
    using (var fileStream = image.OpenReadStream())
    // memory stream
    using (var memoryStream = new MemoryStream())
    {
        fileStream.CopyTo(memoryStream);
        memoryStream.Position = 0; // The position needs to be reset.
        var before = memoryStream.Length;
        ImageOptimizer optimizer = new ImageOptimizer();
        optimizer.LosslessCompress(memoryStream);
        var after = memoryStream.Length;
        // convert to byte[]
        result = memoryStream.ToArray();
    }
    return result;
}
