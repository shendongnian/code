    class EntryItem {
        public EntryItem (EventLogEntry entry) 
        {
            EntryIndex = entry.Index;
            ItemText = string.Format ("{0} - {1} - {2}     - {3}",
                entry.Index,
                entry.EntryType,
                entry.TimeWritten,
                entry.Source);
        }
    
        public string ItemText { get; private set; }
        public int EntryIndex { get; private set; }
    
        public override string ToString ()
        {
            return ItemText;
        }
    }
    
    private EventLog log = new EventLog {
        Log = "System"
    };
    
    private void eventLoader_DoWork (object sender, DoWorkEventArgs e)
    {
        foreach (EventLogEntry entry in this.log.Entries)
            this.Dispatcher.BeginInvoke (() => eventListBox.Items.Add (new EntryItem (entry)));
    }
    
    private void eventListBox_SelectionChanged (object sender, SelectionChangedEventArgs e)
    {
        EntryItem item = eventListBox.SelectedItem as EntryItem;
        if (item == null)
            return;
    
        var entry = log.Entries [item.EntryIndex];
        currentEntryLabel.Content = entry.Message;
    }
