    public static string ImgurUpload()
    {
        ImgurImage streamImage = null;
        using (MemoryStream ms = new MemoryStream(File.ReadAllBytes("test.png")))
        {
            streamImage = AO023ASD.UploadImageAnonymous(ms, "1", "2", "3")
                                  .GetAwaiter().GetResult(); //This is the same as using .Wait()
                                                             //and .Result, but one line
        }
        return streamImage.Link;
    }
