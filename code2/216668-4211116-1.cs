        public class SomeAPITypeWrapper : SomeAPIType
        {
            public override string ToString()
            {
                return SomeProperty;
            }
        }
    
        public class SomeOtherAPITypeWrapper : SomeOtherAPIType
        {
            public override string ToString()
            {
                return SomeOtherProperty;
            }
        }
