c#
using (Bitmap bitmap = (Bitmap)Bitmap.FromFile(@"minibottle.png"))
using (Bitmap bitmapCopy = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format48bppRgb))
{
    using (Graphics gr = Graphics.FromImage(bitmapCopy))
    {
        gr.DrawImage(bitmap, bitmapCopy.Size.ToRect());
    }
    Console.WriteLine($"Original PixelFormat: {bitmap.PixelFormat}"); // Format32bppArgb
    Console.WriteLine($"Copy PixelFormat: {bitmapCopy.PixelFormat}"); //Format48bppRgb
    List<int> rPixels = GetRedValuesWithLockBits(bitmapCopy);
    Console.WriteLine($"R values of all pixels: {string.Join(", ", rPixels)}");  // 237, 238, 238, 236, 232, 234,...
}
where I have moved the bitmap processing to its own method:
c#
private static List<int> _GetRedValuesWithLockBits(Bitmap bitmap)
{
    List<int> result = new List<int>();
    BitmapData bitmapData = bitmap.LockBits(bitmap.Size.ToRect(), ImageLockMode.Read, bitmap.PixelFormat);
    try
    {
        unsafe
        {
            byte* ppixelRow = (byte *)bitmapData.Scan0;
            for (int y = 0; y < bitmap.Height; y++)
            {
                ushort* ppixelData = (ushort *)ppixelRow;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // components are stored in BGR order, i.e. red component last
                    result.Add(ppixelData[2]);
                    ppixelData += 3;
                }
                ppixelRow += bitmapData.Stride;
            }
        }
        return result;
    }
    finally
    {
        bitmap.UnlockBits(bitmapData);
    }
}
and included a little helper extension method:
c#
static class Extensions
{
    public static Rectangle ToRect(this Size size)
    {
        return new Rectangle(new Point(), size);
    }
}
Notes:
* You will have to enable the "Allow unsafe code" setting in the project settings (under the "Build" tab)
* You will notice that the values returned range only from 0 to 8192. One might expect to see values ranging from 0 to 65535, which would be the full range of an unsigned 16-bit value. However, in the .NET code you're using, you're using GDI+ as the underlying graphical support, and [it has this limitation][3]:
>PixelFormat48bppRGB, PixelFormat64bppARGB, and PixelFormat64bppPARGB use 16 bits per color component (channel). GDI+ version 1.0 and 1.1 can read 16-bits-per-channel images, but such images are converted to an 8-bits-per-channel format for processing, displaying, and saving. **Each 16-bit color channel can hold a value in the range 0 through 2^13.**
_[Emphasis mine]_.
In other words, GDI+ allows only values from 0 to 8192 in the color channel. If you try it, you can determine experimentally that in fact, it in fact will also allow values from 8193 through 32767, which is technically 15 bits of color precision. But any value greater than 8192 is treated as if it were 8192. Values greater than 32767 will be displayed as black.
When GDI+ itself is generating the bitmap, as in your example, it will not use values greater than its documented maximum value of 8192.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.getpixel?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color.r?view=netframework-4.8
  [3]: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.pixelformat?view=netframework-4.8#remarks
