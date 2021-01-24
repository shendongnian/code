        [HttpGet]
        [EnableQuery] //This Is added for OData
        public ActionResult<List<TestModel>> Get()
        {
            var model = new List<TestModel>();
            for (int i = 1; i <= 10; i++)
            {
                var res = new TestModel()
                {
                    ID = i,
                    Name="Test"+i,
                    Mobile="Test"+i,
                    City="Test_"+i
                };
                model.Add(res);
            }
            return model;
        }
		public class TestModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Mobile { get; set; }
            public string City { get; set; }
        }
