    public class MyClass
    {
        public string MyDate { get; set; }
        public DateTime? MyDateParsed
        {
            get { return !string.IsNullOrEmpty(MyDate) ? (DateTime?)DateTime.Parse(MyDate) : null; }
        }
    }
