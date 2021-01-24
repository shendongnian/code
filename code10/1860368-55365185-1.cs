 c#
using (var inStream = ...)
using (var outStream = new MemoryStream())
using (var image = Image.Load(inStream, out IImageFormat format))
{
    image.Mutate(
        i => i.Resize(width, height)
              .Crop(new Rectangle(x, y, cropWidth, cropHeight)));
    image.Save(outStream, format);
}
**EDIT**
If you want to leave the original image untouched you can use the `Clone` method instead.
 c#
using (var inStream = ...)
using (var outStream = new MemoryStream())
using (var image = Image.Load(inStream, out IImageFormat format))
{
    var clone = image.Clone(
                    i => i.Resize(width, height)
                          .Crop(new Rectangle(x, y, cropWidth, cropHeight)));
    clone.Save(outStream, format);
}
You might even be able to optimize this into a single method call to [`Resize`][1] via the overload that accepts a `ResizeOptions` instance with `ResizeMode.Crop. That would allow you to resize to a ratio then crop off any excess outside that ratio.
  [1]: https://docs.sixlabors.com/api/ImageSharp/SixLabors.ImageSharp.Processing.ResizeExtensions.html#SixLabors_ImageSharp_Processing_ResizeExtensions_Resize__1_SixLabors_ImageSharp_Processing_IImageProcessingContext___0__SixLabors_ImageSharp_Processing_ResizeOptions_
