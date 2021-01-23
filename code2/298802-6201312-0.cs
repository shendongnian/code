        var r = from table in myDataTable.AsEnumerable()
                orderby table.Field<string>(para1)
                group table by new { Name = table[para1], Y = table[para2] }
                    into ResultTable
                    select new NameCount()
                    {
                        Name = ResultTable.Key,
                        Count = ResultTable.Count()
                    }.ToString();
        
        //Write all r to a File
    }
    public class NameCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string ToString()
        {
            return string.Format("{0},{1}\r\n", Name, Count);
        }
    }
