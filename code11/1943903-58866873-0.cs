      using (var db = new TestEntities())
            {
                var dbCollection = db.Charts.ToList();
                var chartCollection = dbCollection.ToLookup(x => x.ChartID);
                foreach(var chart in chartCollection)
                {
                    Console.WriteLine($"{chart.Key} | {chartCollection[chart.Key].Max(x => x.ChartStatusID)}");
                }
            }
