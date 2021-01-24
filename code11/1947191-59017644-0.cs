     var allRanks = new List<string>
            {
                "1st"
                ,"2nd"
                ,"3rd"
                
            };
            foreach (var entry in result)
            {
                dates.Add(entry.Dates);
            }
            var singleDates = dates.GroupBy(x => x).Select(grp => grp.First()).ToArray();
            Labels = singleDates;
            foreach (var ran in allRanks)
            {
                foreach (var day in singleDates)
                {
                    if (ran == "1st")
                    {
                        if (result.Exists(x => x.Dates == day && x.Rank == ran) == true)
                        {                 
                        SeriesCollection[0].Values.Add(result.Where(w => w.Dates == day && w.Rank == ran).Select(x => x.Amount).First());
                        }
                        else SeriesCollection[0].Values.Add(0);
                    }
                    if (ran == "2nd")
                    {
                        if (result.Exists(x => x.Dates == day && x.Rank == ran) == true)
                        {
                            SeriesCollection[1].Values.Add(result.Where(w => w.Dates == day && w.Rank == ran).Select(x => x.Amount).First());
                        }
                        else SeriesCollection[1].Values.Add(0);
                    }
                    if (ran == "3rd")
                    {
                        if (result.Exists(x => x.Dates == day && x.Rank == ran) == true)
                        {
                            SeriesCollection[2].Values.Add(result.Where(w => w.Dates == day && w.Rank == ran).Select(x => x.Amount).First());
                        }
                        else SeriesCollection[2].Values.Add(0);
                    }
                }
            }
