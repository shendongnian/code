    var GamesDictionary = context.Session["LastPlayed"] as OrderedDictionary;
    if (GamesDictionary  == null)
    {
        // create new
        GamesDictionary = new OrderedDictionary();
    
        // probably! - put it inside
        context.Session["LastPlayed"] = GamesDictionary 
    }
