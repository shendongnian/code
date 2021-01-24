            foreach (var row in _allData)
            {
                if (row.A.Contains(keyword1))
                {
                    row.GroupColumn = 1;
                    continue;
                }
                if(string.IsNullOrEmpty(row.B) || string.IsNullOrEmpty(row.B))
                {
                    row.GroupColumn = 3;
                    continue;
                }
                row.GroupColumn = 2;
            }
