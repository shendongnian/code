    // Custom comparer for the AtomEntry class
    class AtomEntryComparer : IEqualityComparer<AtomEntry>
    {
        // EventEntry are equal if their titles are equal.
        public bool Equals(AtomEntry x, AtomEntry y)
        {
            // adjust as needed
            return x.Title.Text.Equals(y.Title.Text);
        }
        public int GetHashCode(AtomEntry entry)
        {
            // adjust as needed
            return entry.Title.Text.GetHashCode();
        }
    }
    EventFeed eventFeed = service.Query(query)
    var entries = eventFeed.Entries.Distinct(new AtomEntryComparer());
