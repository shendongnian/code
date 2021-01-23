    // Initial query just to get a sequence of { Symbol, Date, Value } entries.
    var entries = from security in ds.securities
                  from valuation in security.timeSeries["liquidity"]
                  select new { Symbol = security.symbol,
                               Date = valuation.Key,
                               valuation.Value };
    // Now do the grouping, sorting and ranking
    var groupedByDate = from entry in entries
                        group entry by entry.Date into date
                        select date.OrderByDescending(x => x.Value)
                                   .ThenBy(x => x.Symbol)
                                   // Use the overload of Select which includes the
                                   // index within the sequence (*after* sorting)
                                   .Select((x, index) => new {
                                        x.Symbol,
                                        x.Value,
                                        x.Date,
                                        Rank = index + 1,
                                    });
    // Now group by symbol again
    var rankingsBySymbol = groupedByDate.SelectMany(day => day)
                                        .ToLookup(tuple => tuple.Symbol,
                                                  tuple => new { tuple.Date,
                                                                 tuple.Value,
                                                                 tuple.Rank });
