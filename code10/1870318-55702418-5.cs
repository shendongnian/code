        string RemoveTags(string file, string tagToRemove, string parentTag)
        {
            XDocument doc = XDocument.Parse(file);
            var remove = doc.Descendants().Where(el => el.Name == tagToRemove && el.Parent.Name == parentTag);
            for (int i = 0; i < remove.Count(); i++)
            {
                remove.ElementAt(i).Parent.Value = remove.ElementAt(i).Value;
            }
            return doc.ToString();
        }
