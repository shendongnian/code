       List<myTask> Task2 = (from t in tempTask 
                             group t by t.Date into g
                             select
                               new myTask
                                 {
                                  ID = new List<int>(g.SelectMany(t => t.ID)),
                                  Date = g.Key,
                                  Total = g.Sum(t => t.Total)
                                 }).ToList();
