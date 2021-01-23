    public class NodeEntryObservableCollection : ObservableCollection<NodeEntry>
    {
        public const string DefaultSeparator = "/";
        public NodeEntryObservableCollection(string separator = DefaultSeparator)
        {
            Separator = separator; // default separator
        }
        /// <summary>
        /// Gets or sets the separator used to split the hierarchy.
        /// </summary>
        /// <value>
        /// The separator.
        /// </value>
        public string Separator { get; set; }
        public void AddEntry(string entry)
        {
            AddEntry(entry, 0);
        }
        /// <summary>
        /// Parses and adds the entry to the hierarchy, creating any parent entries as required.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="startIndex">The start index.</param>
        public void AddEntry(string entry, int startIndex)
        {
            if (startIndex >= entry.Length)
            {
                return;
            }
            var endIndex = entry.IndexOf(Separator, startIndex);
            if (endIndex == -1)
            {
                endIndex = entry.Length;
            }
            var key = entry.Substring(startIndex, endIndex - startIndex);
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            NodeEntry item;
            item = this.FirstOrDefault(n => n.Key == key);
            if (item == null)
            {
                item = new NodeEntry(Separator) { Key = key };
                Add(item);
            }
            // Now add the rest to the new item's children
            item.Children.AddEntry(entry, endIndex + 1);
        }
    }
    public class NodeEntry
    {
        public string Key { get; set; }
        public NodeEntryObservableCollection Children { get; set; }
        public NodeEntry(string separator = NodeEntryObservableCollection.DefaultSeparator)
        {
            Children = new NodeEntryObservableCollection(separator);
        }
    }
