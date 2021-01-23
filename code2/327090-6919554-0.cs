    ...
    select new Dictionary<string, object>
                                {
                                    {"Headline", f.GetString("Headline")},
                                    {"SocialMediaUserID", f.GetLong("SocialMediaUserID")},
                                    // etc..
                                };
