            public List<Row> GetRowsWthoutDuplicates(List<Row> source)
            {
                List<Row> filteredRows = new List<Row>(source);
                foreach (Row row in source)
                {
                    if (!filteredRows.Exists(r => r.Time == row.Time))
                    {
                        filteredRows.Add(row);
                    }
                }
                return
                    filteredRows;
            }
