        public class MyFormField
        {
            public string Name { get; set; }
            public string Value { get; set; }
    
            public bool CheckBoxValue
            {
                get { return Boolean.Parse(Value); }
            }
    
            public MyFormType Type { get; set; }
        }
