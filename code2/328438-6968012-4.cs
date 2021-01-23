        var mapping = LoadSmileys(@"D:\tmp\smileys.txt");
        var smileys = mapping.Keys.OrderByDescending(s => s.Length)
                             .ToArray();
        // Assign an ID like "{93e8b75a-6837-43f8-95ec-801ed59bc167}" to each smiley
        var ids = smileys.Select(key => Guid.NewGuid().ToString("B"))
                         .ToArray();
    
        string text = File.ReadAllText(@"D:\tmp\test_smileys.txt");
        // Replace each smiley with its id
        StringBuilder tmp = new StringBuilder(text);
        for (int i = 0; i < smileys.Length; i++)
        {
            tmp.Replace(smileys[i], ids[i]);
        }
        // Encode the text to HTML
        text = HttpUtility.HtmlEncode(tmp.ToString());
        // Replace each id with the appropriate <img> tag
        tmp = new StringBuilder(text);
        for (int i = 0; i < smileys.Length; i++)
        {
            string image = mapping[smileys[i]];
            tmp.Replace(ids[i], GetImageLink(image));
        }
        
        text = tmp.ToString();
