chsarp
using(var imageStream = File.OpenRead("file"))
{
    var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile,
        BitmapCacheOption.Default);
    var height = decoder.Frames[0].PixelHeight;
    var width = decoder.Frames[0].PixelWidth;
}
**Update 2019-07-07**
If I remember correctly, few months later I found out that dealing with exif'ed images is a little bit more complicated. For some reasons iphones save rotated image instead of normal and they set "rotate this image before displaying" exif flag.  
Also turned out that gif is pretty complicated format. It is possible that no frame has full gif size, you have to aggregate it from offsets and frames sizes.   
  
So I used [ImageProcessor][1] instead, which dealed with all the problems for me. Never checked if it reads the whole file tho.
using (var imageFactory = new ImageFactory())
{
    imageFactory
        .Load(stream)
        .AutoRotate(); //takes care of ex-if
    var height = imageFactory.Image.Height,
    var width = imageFactory.Image.Width
}
  [1]: https://imageprocessor.org
