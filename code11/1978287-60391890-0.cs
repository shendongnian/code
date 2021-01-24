    public class test 
    {
        public class MyValue
        {
            public string Name { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
        }
        public void testing() 
        {
            MyValue value = new MyValue();
            value.Name = "Tony";
            value.Width = "150";
            value.Height = "320";
            dynamic jsonValue = new { keyA = value };
            string height = jsonValue.keyA.Height;
        }
    }
