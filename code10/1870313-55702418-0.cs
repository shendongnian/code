    void RemoveTags(string filename, string tagToRemove, string[] parentTag)
    {
        XDocument doc = XDocument.Load(filename);
        foreach (var parent in parentTag)
        {
            List<XElement> removeList = new List<XElement>();
            foreach (var descendant in doc.Descendants(tagToRemove))
            {
                if (descendant.Parent.Name == parent)
                {
                    removeList.Add(descendant);
                }
            }
            foreach (var element in removeList)
            {
                element.Parent.Value = element.Value;
            }
        }
        doc.Save(filename);
    }
