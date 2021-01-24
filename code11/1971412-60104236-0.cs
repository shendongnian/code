    [NotMapped]
    [JsonIgnore]
    private IList<EntryDetailViewModel> _entries = new List<EntryDetailViewModel>();
    [JsonIgnore]
    public new IReadOnlyList<EntryDetailViewModel> Entries
    {
        get
        {
            return _entries.Where(m => !m.Deleted).ToList().AsReadOnly();
        }
    }
    public void AddEntry(EntryDetailViewModel entry)
    {
        // TODO: Validate entry doesn't already exist, is complete/valid...
        // then...
        _entries.Add(entry);
    }
