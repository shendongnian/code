    var ans = list.OrderBy(x => x.RowType)
                  .ThenBy(x => x.RowNumber)
                  .Aggregate(firstItem => new[] { new { firstItem.RowType, firstItem.RowValue } }.ToList(),
                             (acc, item) => acc.Last().RowType != item.RowType ? acc.AfterAdd(new { item.RowType, item.RowValue })
                                                                               : acc.AfterAdd(new { item.RowType, RowValue = item.RowValue + acc.Last().RowValue })
                            );
