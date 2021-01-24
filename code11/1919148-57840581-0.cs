`cs
if (file.Length > 0)
{
    using(var stream = file.OpenReadStream())
    {
        var image = Image.FromStream(stream);
        int width = (image_height / fullsizeImage.Height) * fullsizeImage.Width;        
        Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size(width, image_height));
        var imgFormat = GetImageFormat(file.FileName);
        using(var ms = new MemoryStream())
        {
            fullSizeBitmap.Save(ms, imgFormat);
            UploadFromStreamAsync(ms);
        }
    }
}
`
The method to get the image format by file extension:
`cs
public ImageFormat GetImageFormat(string fileName)
{
    var dotIndex = fileName.LastIndexOf('.');
    var ext = fileName.Substring(dotIndex, fileName.Length - dotIndex).ToLower();
    switch (ext)
    {
        case ".bmp": return ImageFormat.Bmp;
        case ".emf": return ImageFormat.Emf;
        case ".exif": return ImageFormat.Exif;
        case ".gif": return ImageFormat.Gif;
        case ".icon": return ImageFormat.Icon;
        case ".Jpg": return ImageFormat.Jpeg;
        case ".Jpeg": return ImageFormat.Jpeg;
        case ".png": return ImageFormat.Png;
        case ".tiff": return ImageFormat.Tiff;
        case ".Wmf": return ImageFormat.Wmf;
        default: throw new InvalidDataException("Format not supported");
    }
}
`
If you still need to get the uploaded image encoder info use the below method:
`cs
// ext: image extension
using System.Drawing.Imaging;
public static ImageCodecInfo GetEncoderInfo(string ext)
{
    return ImageCodecInfo.GetImageEncoders().SingleOrDefault(x => x.FilenameExtension.ToLower().Contains(ext));
}
`
