        [TestMethod]
        public void Read()
        {
            var sample1 = @"X:\JsonFilePath\data.json";
            var jsonString=File.ReadAllText(sample1);
            var result =JsonConvert.DeserializeObject<RootObject>(jsonString);
            Assert.IsNotNull(result);
        }
       
