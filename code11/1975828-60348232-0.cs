static private Stream GetImageData(Obj o)
{
    var image = new pdftron.PDF.Image(o);
    var bits = image.GetBitsPerComponent();
    var channels = image.GetComponentNum();
    var bytesPerChannel = bits / 8;
    var height = image.GetImageHeight();
    var width = image.GetImageWidth();
    var data = image.GetImageData();
    var len = height * width * channels * bytesPerChannel;
    using (var reader = new pdftron.Filters.FilterReader(data))
    {
        var buffer = new byte[len];
        reader.Read(buffer);
        return new MemoryStream(buffer);
    }
}
static private void SetImageData(PDFDoc doc, Obj o, Stream stream)
{
    
    var image = new pdftron.PDF.Image(o);
    var bits = image.GetBitsPerComponent();
    var channels = image.GetComponentNum();
    var bytesPerChannel = bits / 8;
    var height = image.GetImageHeight();
    var width = image.GetImageWidth();
    var len = height * width * channels * bytesPerChannel;
    if (stream.Length != len) { throw new DataMisalignedException("Stream length does not match expected image dimensions"); }
    o.Erase("DecodeParms"); // Important: this won'be accurate after SetStreamData
    // now we actually do the stream swap
    o.SetStreamData((stream as MemoryStream).ToArray(), new FlateEncode(null));
}
static private void InvertPixels(Stream stream)
{
    // This function is for DEMO purposes
    // this code assumes 3 channel 8bit
    long length = stream.Length;
    long pixels = length / 3;
    for(int p = 0; p < pixels; ++p)
    {
        int c1 = stream.ReadByte();
        int c2 = stream.ReadByte();
        int c3 = stream.ReadByte();
        stream.Seek(-3, SeekOrigin.Current);
        stream.WriteByte((byte)(255 - c1));
        stream.WriteByte((byte)(255 - c2));
        stream.WriteByte((byte)(255 - c3));
    }
    stream.Seek(0, SeekOrigin.Begin);
}
And then here is sample code to use.
static void Main(string[] args)
{
    PDFNet.Initialize();
    var x = new PDFDoc(@"2002.04610.pdf");
    x.InitSecurityHandler();
    var o = x.GetSDFDoc().GetObj(381);
    Stream source = GetImageData(o);
    InvertPixels(source);
    SetImageData(x, o, source);
    x.Save(@"2002.04610-MOD.pdf", SDFDoc.SaveOptions.e_remove_unused);
}
