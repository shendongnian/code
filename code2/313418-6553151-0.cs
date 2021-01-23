            var grouped = dates.GroupBy(x => x.Month + "/" + x.Year);
            foreach (var v in grouped)
            {
                foreach (var k in v)
                {
                    menuItems.Add(new ArchiveMenuItem(streamUrl, k.Month, k.Year, v.Count()); 
                }
            }
