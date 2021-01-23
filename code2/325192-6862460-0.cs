    public void AppendAllBytes(string path, byte[] bytes)
    {
        //argument-checking here.
        using (var stream = new FileStream(path, FileMode.Append))
        {
            stream.Write(bytes, 0, bytes.Length);
        }
    }
