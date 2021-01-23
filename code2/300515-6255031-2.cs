        class SampleData
        {
            [JsonProperty(PropertyName = "items")]
            public System.Data.DataTable Items { get; set; }
        }
        [Test]
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
            Assert.AreEqual("Name", table.Columns[0].ColumnName);
            Assert.AreEqual("Age", table.Columns[1].ColumnName);
            Assert.AreEqual("Job", table.Columns[2].ColumnName);
            Assert.AreEqual("AAA", table.Rows[0]["Name"]);
            Assert.AreEqual("BBB", table.Rows[1]["Name"]);
            Assert.AreEqual("CCC", table.Rows[2]["Name"]);
            Assert.AreEqual("22", table.Rows[0]["Age"]);
            Assert.AreEqual("25", table.Rows[1]["Age"]);
            Assert.AreEqual("38", table.Rows[2]["Age"]);
            Assert.AreEqual("PPP", table.Rows[0]["Job"]);
            Assert.AreEqual("QQQ", table.Rows[1]["Job"]);
            Assert.AreEqual("RRR", table.Rows[2]["Job"]);
        }
