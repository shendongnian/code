    private static string GetImageResourceName(byte[] pdfStream) {
        using (MemoryStream ms = new MemoryStream(pdfStream)) {                
            ms.Seek(2, SeekOrigin.Begin);   // skip first 2 bytes (zlib header)
                
            using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress)) {
                using (StreamReader sr = new StreamReader(ds)) {
                    string contents = sr.ReadToEnd();
                    // PostScript command referencing the image resource looks like: /img123 Do
                    return Regex.Match(contents, @"\b(img\d+)\s+Do\b").Groups[1].Value;
                }
            }
        }
    }
