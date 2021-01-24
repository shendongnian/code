    public class MyTestClass
    {
        public const string DATETIME_FORMAT = "MM-DD-YYYY";
        public int id { get; set; }
        public string dateTime { get; set; }
        public DateTime dateTimeConverted
        {
            get
            {
                string[] parts = dateTime.Split('-');
                int year, month, day;
                
                if (DATETIME_FORMAT == "MM-DD-YYYY")
                {
                    year = Int32.Parse(parts[2]);
                    month = Int32.Parse(parts[0]);
                    day = Int32.Parse(parts[1]);   
                }
                else if (DATETIME_FORMAT == "DD-MM-YYYY")
                {
                    year = Int32.Parse(parts[2]);
                    month = Int32.Parse(parts[1]);
                    day = Int32.Parse(parts[0]); 
                }
                return new DateTime(year, month, day);
            }
        }
