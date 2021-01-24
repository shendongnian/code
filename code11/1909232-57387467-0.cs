c#
public string PostImage(Stream stream)
{
    using (var f = new FileStream(@"C:\Temp\Sample.jpg", FileMode.OpenOrCreate))
    {
        stream.CopyTo(f);
    }
    stream.Close();
    return "Recieved the image on server";
}
