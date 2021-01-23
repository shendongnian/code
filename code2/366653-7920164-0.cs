    progress = progress.Concat(from ba in baTable
                           from hs in historyTable
                           where hs.OrderNumber == ba.OrderNumber
                           select new {
                               Position = ba.Position.ToString(),
                               Time = hs.Time.ToString(),
                               Seq = ""
                           });
