            List<SingleSeries> series = new List<SingleSeries>();
            var kpiQuery = kpis;
            //Iterate intervals and build a single query to retrieve all of them
            for (int i = 0; i < intervals.Count(); i++)
            {
                if (i + 1 < intervals.Count())
                {
                    // add each target interval sequentially - without running the query yet
                    kpiQuery = kpiQuery.Where(x => x.Date >= intervals.ElementAt(i) && x.Date < intervals.ElementAt(i + 1));
                }
            }
            var validKpis = kpiQuery.ToList(); // now get all database results in a single transaction
            //Iterate the intervals again, this time to split the combined results that are now in memory
            for (int i = 0; i < intervals.Count(); i++)
            {
                if (i + 1 < intervals.Count())
                {
                    //select only the results applicable to the current interval
                    var kpisInThisInterval = validKpis.Where(x =>
                        x.Date >= intervals.ElementAt(i) && x.Date < intervals.ElementAt(i + 1));
                    //Apply calc operation (SUM; AVG; MAX;MIN)
                    var result = CalcOperations.Calculate(calcOperation, kpisInThisInterval);
                    //Add result to results array
                    series.Add(new SingleSeries()
                    {
                        Value = result,
                        Name = DateOperations.ConvertToMilliseconds(intervals.ElementAt(i + 1)).ToString()
                    });
                }
            }
            return series;
