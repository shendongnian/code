                    var _cells = worksheet.Cells;
                    var dictionary = _cells
                         .GroupBy(c => new { c.Start.Row, c.Start.Column })
                           .ToDictionary(
                                rcg => new KeyValuePair<int, int>(rcg.Key.Row, rcg.Key.Column),
                                rcg => _cells[rcg.Key.Row, rcg.Key.Column].Value).Where(a => a.Value != null);
