        class SampleData
        {
            [JsonProperty(PropertyName = "items")]
            public System.Data.DataTable Items { get; set; }
        }
        public void DerializeTable()
        {
            const string json = @"{items:["
                + @"{""Name"":""AAA"",""Age"":""22"",""Job"":""PPP""},"
                + @"{""Name"":""BBB"",""Age"":""25"",""Job"":""QQQ""},"
                + @"{""Name"":""CCC"",""Age"":""38"",""Job"":""RRR""}]}";
            var sampleData = JsonConvert.DeserializeObject<SampleData>(json);
            var table = sampleData.Items;
            // write tab delimited table without knowing column names
            var line = string.Empty;
            foreach (DataColumn column in table.Columns)            
                line += column.ColumnName + "\t";                       
            Console.WriteLine(line);
            foreach (DataRow row in table.Rows)
            {
                line = string.Empty;
                foreach (DataColumn column in table.Columns)                
                    line += row[column] + "\t";                                   
                Console.WriteLine(line);
            }
            // Name   Age   Job    
            // AAA    22    PPP    
            // BBB    25    QQQ    
            // CCC    38    RRR    
        }
