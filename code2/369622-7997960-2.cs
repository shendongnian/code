    var lowestPriceBars = bars.GroupBy(bar => new { bar.BeginTime, bar.EndTime, bar.Date })
                              .SelectMany(timeGroup => timeGroup
                                                       .GroupBy(bar => bar.Price)
                                                       .OrderBy(priceGroup => priceGroup.Key)
                                                       .First())
                              .ToArray();
