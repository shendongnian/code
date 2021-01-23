    byte[] bytes = File.ReadAllBytes(inFilePath);
    using (MemoryStream ms = new MemoryStream())
    {
        // You could also just use StreamWriter to do "writer.Write(bytes)"
        ms.Write(bytes, 0, bytes.Length);
        using (StreamWriter writer = new StreamWriter(ms))
        {
            writer.Write("Some Data");
        }
        File.WriteAllBytes(outFilePath, ms.ToArray());
    }
