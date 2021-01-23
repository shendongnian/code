    static void Main(string[] args)
    {
        string imageUrl = "http://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png";
        byte[] pngSignature = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 };
        HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(imageUrl);
        wReq.AddRange(0, 30);
        WebResponse wRes = wReq.GetResponse();
        byte[] buffer = new byte[30];
        int width = 0;
        int height = 0;
    
        using (Stream stream = wRes.GetResponseStream())
        {
            stream.Read(buffer, 0, 30);
        }
    
        // Check for Png
        // 8 byte - Signature
        // 4 byte - Chunk length
        // 4 byte - Chunk type - IDHR (Image Header)
        // 4 byte - Width
        // 4 byte - Height
        // Other stuff we don't care about
        if (buffer.Take(8).SequenceEqual(pngSignature))
        {
            var idhr = buffer.Skip(12);
            width = BitConverter.ToInt32(idhr.Skip(4).Take(4).Reverse().ToArray(), 0);
            height = BitConverter.ToInt32(idhr.Skip(8).Take(4).Reverse().ToArray(), 0);
        }
        // Check for Jpg
        //else if (buffer.Take(?).SequenceEqual(jpgSignature))
        //{
        //    // Do Jpg stuff
        //}
        // Check for Gif
        //else if (etc...
    
        Console.WriteLine("Width: " + width);
        Console.WriteLine("Height: " + height);
        Console.ReadKey();
    }
