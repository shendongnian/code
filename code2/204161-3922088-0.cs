            var col = ds.Tables[0].Columns["IndexPrethodni"];
            var row = ds.Tables[0].Rows[0];
            if (!row.IsNull(col))
            {
                string s = row[col].ToString();
                ...
            }
