    var mergedRows = rows.GroupBy(x => x.Cells[0].Value.ToString())
                .Select(x => new Row() { Cells = new List<Cell>
                                                    {
                                                       new Cell() { Value = x.Key },
                                                       new Cell() { Value = x.Sum(y => int.Parse(y.Cells[1].Value.ToString())) }
                                                    }
                                       });
