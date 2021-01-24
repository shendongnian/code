               int? EOF = dt.AsEnumerable()
                    .Select((x, i) => new { row = x, index = i })
                    .Where(x => x.row.Field<string>("CHECK_SUM") == "EOF")
                    .Select(x => x.index)
                    .FirstOrDefault();
                if(EOF != null)
                {
                   DataTable dt2 = dt.AsEnumerable()
                       .Where((x, i) => i < EOF)
                       .CopyToDataTable();
                }
