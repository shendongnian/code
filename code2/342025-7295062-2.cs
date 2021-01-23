    Dictionary<int, string> sites = new Dictionary<int, string>() 
    {
        { 19, "Facebook" },
        { 20, "Twitter" },
        { 21, "YouTube" },
        { 23, "Flickr" }, 
        { 25, "Blogs" },
    };
    //
    string str2;
    if (!sites.TryGetValue(i, out str2))
    {
        throw new Exception();
    }
    // str2 contains your site description
