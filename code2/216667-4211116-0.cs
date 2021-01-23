        public class SomeAPIType
        {
            public string SomeProperty { get; set; }
            public override string ToString()
            {
                return SomeProperty;
            }
        }
    
        public class SomeOtherAPIType
        {
            public string SomeOtherProperty { get; set; }
            public override string ToString()
            {
                return SomeOtherProperty;
            }
        }
