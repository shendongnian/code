    enum Sites
    {
        Facebook = 19,
        Twitter = 20,
        YouTube = 21,
        Flickr = 23,
        Blogs = 25,
    }
    //
    int i = 19;
    if (!Enum.IsDefined(typeof(Sites), i))
    {
        throw new Exception();
    }
    string str = ((Sites)i).ToString();
