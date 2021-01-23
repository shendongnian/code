    class StringContainer { 
        public string Value { get; set; }
    }
    Dictionary<int, StringContainer> values;
    var value1 = new StringContainer { Value = "ABC" };
    values.Add(1, value1);
    values.Add(2, value1);
