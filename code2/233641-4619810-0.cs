    public FileStreamResult GetPersonImage(int pid)
    {
        string src = so.GetPersonImage(pid);
        byte[] imageBytes = Convert.FromBase64String(src);
        MemoryStream ms = new MemoryStream(imageBytes);
        Response.Clear();
        Response.Expires = 0;
        Response.AddHeader("Content-Length", imageBytes.Length.ToString());
        Response.BufferOutput = false;
        return new FileStreamResult(ms, "image/png");
    }
