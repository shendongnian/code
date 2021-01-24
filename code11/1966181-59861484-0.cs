using(Image img = Image.FromFile(file))
using(var imgRes = ResizeImage(img, ImageSettings.Width, ImageSettings.Height))
using(var memoryStream = new MemoryStream(10_000_000))
{
    img.Save(memoryStream, ImageFormat.Png);
    var label = Directory.GetParent(file).Name;
    var bytes = memoryStream.ToArray();
    db.Add(new ImageData { Image = bytes, Label = label });
}
There's no need to close `MemoryStream`, it's just a wrapper over an array. That still allocates a big buffer for each file though. 
If we know the maximum file size, we can allocate a *single* buffer and reuse it in all iterations. In this case the size matters - it's no longer possible to resize the buffer :
var buffer=new byte[100_000_000];
using(Image img = Image.FromFile(file))
using(var imgRes = ResizeImage(img, ImageSettings.Width, ImageSettings.Height))
using(var memoryStream = new MemoryStream(buffer))
{
    img.Save(memoryStream, ImageFormat.Png);
    var label = Directory.GetParent(file).Name;
    var bytes = memoryStream.ToArray();
    db.Add(new ImageData { Image = bytes, Label = label });
}
