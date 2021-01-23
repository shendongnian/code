    var query = from c in ScanLogs
                join d in Exhibits on c.ExhibitID equals d.ExhibitID
                group new{
                 g.Key.ContactID,
                 g.Key.EventID,
                 Count = g.Count()
                }
                by new {
                  c.ContacID, d.EventID
                } into g
                select g;
 
