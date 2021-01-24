    from scan in Scans
    group new { scan.ScanDate, Qty = scan.Items.Sum(i => i.Qty) } // <--
    by new { scan.ScanUser.Name, scan.ScanUser.Id } into g
    select new
    {
        UserId = g.Key.Id,
        Name = g.Key.Name,
        LastSyncTime = g.Max(x => x.ScanDate),
        ScanItems = g.Sum(x => x.Qty) // <--
    }
