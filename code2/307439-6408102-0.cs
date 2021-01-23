    using (var ff = new MemoryStream())
    {
    using (var f = new StreamWriter(ff))
    {
    //Some Code
    }
    //Stream ff is closed, because the StreamWriter has been closed while exiting the inner using statement
    }
