        void RemoveTags(string filename, string tagToRemove, string parentTag)
        {
            XDocument doc = XDocument.Load(filename);
            var remove = doc.Descendants().Where(el => el.Name == tagToRemove && el.Parent.Name == parentTag);
            for (int i = 0; i < remove.Count(); i++)
            {
                remove.ElementAt(i).Parent.Value = remove.ElementAt(i).Value;
            }
            doc.Save(filename);
        }
