    var query = from entry in myList
                where status.Contains(entry.Status)
                group entry.Routes.First() // take the first item in each route
                    by new // assuming each id has a unique name
                    {
                        entry.ItemID,
                        entry.Name
                    }
                    into g
                select new
                {
                    g.Key.ItemID,
                    g.Key.Name,
                    ListOfRoutes = g.ToList() // return the grouping as list
                };
