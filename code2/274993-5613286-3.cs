        // get all the text within {} pairs
        var pattern = @"\{(.*?)\}";
        var query = "{Hello|Hi|Hi-Hi} my {mate|m8|friend|friends}.";
        var matches = Regex.Matches(query, pattern);
        
        // create a List of Lists
        for(int i=0; i< matches.Count; i++)
        {
            var nl = matches[i].Groups[1].ToString().Split('|').ToList();
            lists.Add(nl);
            // build a "template" string like "{0} my {1}"
            query = query.Replace(matches[i].Groups[1].ToString(), i.ToString());
        }
 
