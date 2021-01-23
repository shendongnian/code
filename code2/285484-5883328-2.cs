        string text = "London is a great city and have football events " +
           "in London but party sites in London are also good. London " +
           "football events are great along with London party sites. " +
           "Enjoy London!";
        
        // Build sorted map of phrases to URLs.
        // Phrases that can appear with different capitalization
        // need to be stored multiple times.
        SortedDictionary<string, string> phrasesToUrls =
            new SortedDictionary<string, string>(new StringLengthComparer());
        phrasesToUrls.Add(
            "Football events in London",
            "http://www.mysite/footbal-events/london");
        phrasesToUrls.Add(
            "football events in London",
            "http://www.mysite/footbal-events/london");
        phrasesToUrls.Add(
            "London football events",
            "http://www.mysite/footbal-events/london");
        phrasesToUrls.Add(
            "London",
            "http://www.mysite/london-events/london");
        phrasesToUrls.Add(
            "Party sites in London",
            "http://www.mysite/party-sites/london");
        phrasesToUrls.Add(
            "party sites in London",
            "http://www.mysite/party-sites/london");
        phrasesToUrls.Add(
            "London party sites",
            "http://www.mysite/party-sites/london");
        // phase 1: replace phrases to be linked with unique placeholders
        Dictionary<string, string> placeholdersToLinks =
            new Dictionary<string, string>();
        foreach (KeyValuePair<string, string> pair in phrasesToUrls)
        {
            // Replace phrases with placeholders.
            string placeholder = Guid.NewGuid().ToString();
            text = text.Replace(pair.Key, placeholder);
            // Create dictionary of links by placeholder
            string link = "<a href=\"" +
                pair.Value +
                "\">" +
                pair.Key +
                "</a>";
            placeholdersToLinks.Add(placeholder, link);
        }
        // Phase 2: replace unique placeholders with links.
        foreach (KeyValuePair<string, string> pair in placeholdersToLinks)
        {
            text = text.Replace(pair.Key, pair.Value);
        }
