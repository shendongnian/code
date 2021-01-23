    var result = from s in pdc.ScanLogs
                    from e in pdc.Exhibits
                    from ce in pdc.ClientEvents
                    where s.ExhibitID == e.ExhibitID
                    && e.ClientEventID == ce.ClientEventID
                    group new { s, e, ce } by new { ce.EventID } into d
                    select new
                    {
                        EventID = d.Key.EventID,
                        Count = d.Count(),
                        CountOptIn = d.Count(item => item.s.OptIn == "Yes")
                    }; 
