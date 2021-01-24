        public static List<DataTest> CountAndFrequency(IEnumerable<DataRecord> records, string ColumnName, int numResults)
        {
            foreach (DataRecord record in records)
            {
                var prop = typeof(DataRecord).GetProperty(ColumnName);
                var value = prop.GetValue(record).ToString().ToUpper();
                prop.SetValue(record, value);
            }
        }
