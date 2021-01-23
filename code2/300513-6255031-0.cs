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
            var table = JsonConvert.DeserializeObject<SampleData>(json);
            Assert.AreEqual("AAA", table.Items.Rows[0]["Name"]);
            Assert.AreEqual("BBB", table.Items.Rows[1]["Name"]);
            Assert.AreEqual("CCC", table.Items.Rows[2]["Name"]);
        }
