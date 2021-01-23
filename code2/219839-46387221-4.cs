        public class NoneValidationMode : RequiredValidationMode
        {
            public NoneValidationMode() { }
            public  override bool IsValid(string properties, object value)
            {
                //validation code here
            }
        }
        public class AllValidationMode: RequiredValidationMode
        {
            public   override bool IsValid(string properties,object value)
            {
                //validation code here
            }
        }
        public class AtLeastOneValidationMode : RequiredValidationMode
        {
            public  override bool IsValid(string properties, object value)
            {
                //validation code here
            }
        }
        public abstract class RequiredValidationMode
        {
            public abstract bool IsValid(string properties, object value);
        }
