    public class MyObject : ValidatingObject
    {
        public MyObject()
        {
            // Add Properties to Validate here
            this.ValidatedProperties.Add("SomeNumber");
        }
    
        // Implement validation rules here
        public override string GetValidationError(string propertyName)
        {
            if (ValidatedProperties.IndexOf(propertyName) < 0)
            {
                return null;
            }
        
            string s = null;
        
            switch (propertyName)
            {
                case "SomeNumber":
                    if (SomeNumber <= 0)
                        s = "SomeNumber must be greater than 0";
                    break;
            }
        
            return s;
        }
    
    }
