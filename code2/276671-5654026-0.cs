    class SomeClass
    {
        public string Property0 { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }
        public string Property4 { get; set; }
        public string Property5 { get; set; }
        public string Property6 { get; set; }
        public string Property7 { get; set; }
        public string Property8 { get; set; }
        public string Property9 { get; set; }
        public override string ToString()
        {
            //just to print out all properties and values
            foreach (PropertyInfo prop in typeof(SomeClass).GetProperties())
            {
                Console.WriteLine(prop.Name + "," + prop.PropertyType + " = " + prop.GetValue(this, null));
            }
            return base.ToString();
        }
        public void CopyStringPropertiesIfEmptyFrom(SomeClass SourceInstance)
        {
            foreach (PropertyInfo prop in typeof(SomeClass).GetProperties())
            {
                if (prop.PropertyType == typeof(System.String) && String.IsNullOrEmpty((string)prop.GetValue(this, null)))
                {
                    prop.SetValue(this, prop.GetValue(SourceInstance, null), null);
                }
            }
        }
    }
