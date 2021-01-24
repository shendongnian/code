    class MyCls
    {
        public List<TestData> MyData {get;set;}
        public MyCls (List<MY_SP_Result> data)
        {
            MyData = new List<TestData>();
            
            foreach(var id in data.GroupBy(d => d.Id).Select(g => g.Key).ToList()) 
            {
                var dt = new TestData {
                    TEST_VAL = id,
                    Data = data.Where(d => d.Id == id).ToList()
                };
    	
                MyData.Add(dt);
            }
        }
    }
