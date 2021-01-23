        private void Parsing_String(string filename)
        {
            List<Row> list = new List<Row>();
            foreach (String str in File.ReadLines(filename))
            {
                String[] strCols = str.Split(Convert.ToChar(" "));
                list.Add(new Row() 
                {
                    Column1 = strCols[0].Substring(2),
                    Column2 = strCols[1].Substring(2),
                    Column3 = strCols[2].Substring(2),
                    Column4 = strCols[3].Substring(2),
                    Column5 = strCols[4].Substring(2),
                    Column6 = strCols[5].Substring(2)
                });
            }
            dg.ItemsSource = list;
        }
        public class Row
        {
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public string Column3 { get; set; }
            public string Column4 { get; set; }
            public string Column5 { get; set; }
            public string Column6 { get; set; }
        }
    
