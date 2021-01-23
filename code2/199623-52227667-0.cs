    using System; using System.IO; using System.Text;
    // Using encoding from BOM or UTF8 if no BOM found,
    // check if the file is valid, by reading all lines
    // If decoding fails, use the local "ANSI" codepage
    public string DetectFileEncoding(Stream fileStream)
    {
        var Utf8EncodingVerifier = Encoding.GetEncoding("utf-8", new EncoderExceptionFallback(), new DecoderExceptionFallback());
        using (var reader = new StreamReader(fileStream, Utf8EncodingVerifier,
               detectEncodingFromByteOrderMarks: true, leaveOpen: true, bufferSize: 1024))
        {
            string detectedEncoding;
            try
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                }
                detectedEncoding = reader.CurrentEncoding.BodyName;
            }
            catch (Exception e)
            {
                // Failed to decode the file using the BOM/UT8. 
                // Assume it's local ANSI
                detectedEncoding = "ISO-8859-1";
            }
            // Rewind the stream
            fileStream.Seek(0, SeekOrigin.Begin);
            return detectedEncoding;
       }
    }
    [Test]
    public void Test1()
    {
        Stream fs = File.OpenRead(@".\TestData\TextFile_ansi.csv");
        var detectedEncoding = DetectFileEncoding(fs);
        using (var reader = new StreamReader(fs, Encoding.GetEncoding(detectedEncoding)))
        {
           // Consume your file
            var line = reader.ReadLine();
            ...
