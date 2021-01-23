    var GamesDictionary = context.Session["LastPlayed"] as OrderedDictionary;
    if (GamesDictionary  != null)
    {
        // do stuff
    }
    else
    {
        // create new
        GamesDictionary = new OrderedDictionary();
    
        // probably! - put it inside
        context.Session["LastPlayed"] = GamesDictionary 
    }
