        public static void MapRowNumber(this IEnumerable<RowInfo<MyPocoFromExcelBase>> sequence, string fileName)
        {
            if (sequence == null) return;
            foreach (var item in sequence)
            {
                item.Value.Filename = fileName;
                item.Value.RowNumber = item.RowNumber;
            }
        }
