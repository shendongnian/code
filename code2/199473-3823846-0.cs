    var groupedDates = l.Select(date => DateTime.ParseExact(date, "yyyy.MM.dd'T'HH",
                                        CultureInfo.InvariantCulture))
                        .GroupBy(date => date.Year)
                        .Select(yg => new { Year = yg.Key, Months = yg
                            .GroupBy(ydate => ydate.Month)
                            .Select(mg => new { Month = mg.Key, Days = mg
                                .GroupBy(mdate => mdate.Day)
                                .Select(dg => new { Day = dg.Key, Hours = dg
                                    .GroupBy(ddate => ddate.Hour)
                                })
                            })
                        });
