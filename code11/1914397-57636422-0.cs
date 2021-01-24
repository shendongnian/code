            static void Main(string[] args)
            {
                int[] array = Enumerable.Range(1, 1000).ToArray();
                int[][] pages = array.GroupBy(x => (x - 1) / 112).Select(x => x.ToArray()).ToArray();
                int[][] rows = pages.SelectMany(x => x.GroupBy(y => (y - 1) % 28)).Select(y => y.ToArray()).ToArray();
                DataTable dt = new DataTable();
                dt.Columns.Add("Col A", typeof(int));
                dt.Columns.Add("Col B", typeof(int));
                dt.Columns.Add("Col C", typeof(int));
                dt.Columns.Add("Col D", typeof(int));
                foreach (int[] row in rows)
                {
                    DataRow newRow = dt.Rows.Add(new object[] { 
                        row[0], 
                        (row.Length > 1) ? (object)row[1] : null,
                        (row.Length > 2) ? (object)row[2] : null,
                        (row.Length > 3) ? (object)row[3] : null
                    });
                    
                }
            }
