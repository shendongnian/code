    class TableGuess
    {
        private List<string[]> rows = new List<string[]>();
        private List<ColumnGuess> columns;
        public string Name { get; set; }
        public void AddColumns(IEnumerable<string> columns)
        {
            this.columns = columns.Select(cc => new ColumnGuess { Name = cc })
                                  .ToList();
        }
        public void AddRow(string[] parts)
        {
            for (int ii = 0; ii < parts.Length; ++ii)
            {
                if (String.IsNullOrEmpty(parts[ii])) continue;
                columns[ii].ImproveType(parts[ii]);
            }
            this.rows.Add(parts);
        }
    }
