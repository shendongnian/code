    private DataTable StripEmptyRows(DataTable dt)
        {
            List<int> rowIndexesToBeDeleted = new List<int>();
            int indexCount = 0;
            foreach(var row in dt.Rows)
            {
                var r = (DataRow)row;
                int emptyCount = 0;
                int itemArrayCount = r.ItemArray.Length;
                foreach(var i in r.ItemArray) if (string.IsNullOrEmpty(i.ToString())) emptyCount++;
                if(emptyCount == itemArrayCount) rowIndexesToBeDeleted.Add(indexCount);
                indexCount++;
            }
            int count = 0;
            foreach(var i in rowIndexesToBeDeleted)
            {
                dt.Rows.RemoveAt(i-count);
                count++;
            }
            return dt;
        }
