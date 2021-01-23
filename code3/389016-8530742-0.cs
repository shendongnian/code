    foreach (var item in events
            .Where(e => e.Type = EntryType.Entry)
            .GroupBy(e => new { e.Time.Date, e.Name })  // I think, kinda forget
            .Select(ge => new { ge.Key.Date, ge.Key.Name, Count = ge.Count() }))
    {
        MessageBox.Show(...);
    }
