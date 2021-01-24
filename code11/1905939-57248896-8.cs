    public class Tab
    {
        public string TabName { get; set; }
        public DataTable Content { get; set; }
    
        public Tab(string name, DataTable content)
        {
            TabName = name;
            Content = content;
        }
    
        public Tab(string name, List<string[]> content)
        {
    
            Content = new DataTable();
            foreach (var item in content){
                Content.Columns.Add(item[0], typeof(string));
            }
            DataRow row = Content.NewRow();
            foreach (var item in content)
            {
                row[item[0]] = item[1];
            }
            Content.Rows.Add(row);
            TabName = name;
        }
    }
