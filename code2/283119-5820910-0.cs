    var bars = from tick in ticks
               let barNumberForDay = tick.Timestamp.TimeOfDay.Ticks / barSizeInTicks
               let barBeginTime = tick.Timestamp.Date.AddTicks
                                  (barNumberForDay * barSizeInTicks)
               group tick by barBeginTime into tickGroup
               let orderedPrices = tickGroup.OrderBy(t => t.Timestamp)
                                            .Select(t => t.Price)
               select new Bar
               {
                    Open = orderedPrices.First(),
                    Close = orderedPrices.Last(),
                    High = orderedPrices.Max(),
                    Low = orderedPrices.Min(),
                    BeginTime = tickGroup.Key,
                    EndTime = tickGroup.Key.AddSeconds(barSizeInTicks)
               };
