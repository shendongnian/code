    var bars = from tick in ticks
                
               // Calculates the chronological, natural-time, intra-day index 
               // of the bar associated with a tick.
               let barIndexForDay = tick.Timestamp.TimeOfDay.Ticks / barSizeInTicks
             
               // Calculates the begin-time of the bar associated with a tick.
               // For example, turns 2011/04/28 14:23.45 
               // into 2011/04/28 14:20.00, assuming 5 min bars.
               let barBeginDateTime = tick.Timestamp.Date.AddTicks
                                  (barIndexForDay * barSizeInTicks)
               // Produces raw tick-data for each bar by grouping.
               group tick by barBeginDateTime into tickGroup
               // Order prices for a group chronologically.
               let orderedPrices = tickGroup.OrderBy(t => t.Timestamp)
                                            .Select(t => t.Price)
               select new Bar
               {
                    Open = orderedPrices.First(),
                    Close = orderedPrices.Last(),
                    High = orderedPrices.Max(),
                    Low = orderedPrices.Min(),
                    BeginTime = tickGroup.Key,
                    EndTime = tickGroup.Key.AddTicks(barSizeInTicks)
               };
