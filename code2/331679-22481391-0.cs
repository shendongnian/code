     [HttpGet]
        public string GetJson()
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            List<DataEntry> properties = new List<DataEntry>();
            for (int i = 0; i < 10; i++)
            {
                properties.Add(new DataEntry { Column = "column" + i.ToString(), Value = "value" + i.ToString() });
            }
            list.Add(properties.ToDictionary(x => x.Column, y => y.Value));
            string test = JsonConvert.SerializeObject(list);
            return test;
        }
 
