    public class NodeEntry
    {
        public NodeEntry()
        {
            this.Children = new NodeEntryCollection();
        }
        public string Key { get; set; }
        public NodeEntryCollection Children { get; set; }
    }
    public class NodeEntryCollection : Dictionary<string, NodeEntry>
    {
        public void AddEntry(string sEntry, int wBegIndex)
        {
            if (wBegIndex < sEntry.Length)
            {
                string sKey;
                int wEndIndex;
                wEndIndex = sEntry.IndexOf("/", wBegIndex);
                if (wEndIndex == -1)
                {
                    wEndIndex = sEntry.Length;
                }
                sKey = sEntry.Substring(wBegIndex, wEndIndex - wBegIndex);
                if (!string.IsNullOrEmpty(sKey)) {
                    NodeEntry oItem;
                    if (this.ContainsKey(sKey)) {
                        oItem = this[sKey];
                    } else {
                        oItem = new NodeEntry();
                        oItem.Key = sKey;
                        this.Add(sKey, oItem);
                    }
                    // Now add the rest to the new item's children
                    oItem.Children.AddEntry(sEntry, wEndIndex + 1);
                }
            }
        }
    }
