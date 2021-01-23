    private Dictionary<IDirectoryEntry, PropertyChangedEventHandler> eventHandlers =
        new Dictionary<IDirectoryEntry, PropertyChangedEventHandler>();
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
        eventHandlers[entry] = h;
        entry.PropertyChanged += h;
        Entries.Add(entry.Name, entry);
    }
    public void Remove(IDirectoryEntry entry) {
        if (Entries[entry.Name] == entry) {
            Entries.Remove(entry.Name);
            eventHandlers.Remove(entry);
        }
    }
