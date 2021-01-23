    byte[] data;
    
    using(System.IO.MemoryStream stream = new System.IO.MemoryStream())
    {
        image.Save(stream);
        data = stream.ToArray();
    }
