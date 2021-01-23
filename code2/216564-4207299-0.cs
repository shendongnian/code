    public void Add(IDirectoryEntry entry) {
        string oldName = entry.Name;
        PropertyChangedEventHandler h;
        h = (o, args) => {
            if (args.PropertyName == "Name" &&
                    entry.Name != oldName &&
                    Entries[oldName] == entry) {
                entry.PropertyChanged -= h;
                Entries.Remove(oldName);
                Add(entry);
            }
        };
        entry.PropertyChanged += h;
        Entries.Add(entry.Name, entry);
    }
