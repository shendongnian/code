    [DataContract]
    public class MyClass
    {
        // No DataMember attribute here
        public double MyProperty { get; set; }
        
        // Serialize this property instead
        [DataMember(Name = "MyProperty")]
        private string MyPropertyXml
        {
            get { return MyProperty.ToString("P", CultureInfo.InvariantCulture); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    MyProperty = 0;
                }
                else
                {
                    string s = value.TrimEnd('%', ' ');
                    MyProperty = double.Parse(s, CultureInfo.InvariantCulture) / 100;
                }
            }
        }
    }
