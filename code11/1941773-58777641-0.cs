     static void Main(string[] args)
        {
            var listOfIds = new List<string>();
            string html = " id=\"MLA12334566\"  id=\"MLA123354566\" id=\"MLA123346566\"";
            Regex idRegex = new Regex("id=\"(MLA[0-9]{6,})\"");
            var matches = idRegex.Matches(html);
    
            foreach(var match in matches)
            {
                listOfIds.Add(match.ToString());
            }
        }
