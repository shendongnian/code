    public class TestModel : IDataErrorInfo
    {
        public List<DateTime> MyCollection {get; set;}
        public string this[string columnName]
        {
            get { return this.GetValidationError(propertyName); }
        }
    
        public string GetValidationError(string propertyName)
        {
            switch (propertyName)
            {
                case "MyCollection":
                    // Do validation here and return a string if an error is found
                    if (MyCollection == null) return "Collection not Initialized";
            }
            return null;
        }
    }
