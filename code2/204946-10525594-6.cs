        static DirectoryEntry[] GetAllChildren(DirectoryEntry entry)
        {
            List<DirectoryEntry> children = new List<DirectoryEntry>();
            foreach (DirectoryEntry child in entry.Children)
            {
                children.Add(child);
                children.AddRange(GetAllChildren(child));
            }
            return children.ToArray();
        }
