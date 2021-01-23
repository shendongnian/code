    var indexes = from row in Enumerable.Range(0, rows)
                  from column in Enumerable.Range(0, columns)
                  select new { Row = row, Column = column };
    var ls = indexes.Select(index => new L(index.Row, index.Column));
    var gs = ls.Select(l => new G(this, l, 0, 20, 30)).ToList();
    var gList = gs.ToList();
        
