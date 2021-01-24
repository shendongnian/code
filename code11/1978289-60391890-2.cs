    public class test
    {
        public class MyValue
        {
            public string Name { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
        }
        Dictionary<string, MyValue> dic = new Dictionary<string, MyValue>();
        public void testing()
        {
            string key = "Mykey" + NextNumber.toString();
            MyValue value = new MyValue();
            value.Name = "Tony";
            value.Width = "150";
            value.Height = "320";
            dic.Add(key, value);
        }
    }
