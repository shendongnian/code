    public FileContentResult Track(Guid id)
    {
        //do tracking stuff ....
        //return empty gif
        const string clearGif1X1 = "R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==";
        return new FileContentResult(
                           Convert.FromBase64String(clearGif1X1), "image/gif");
    }
