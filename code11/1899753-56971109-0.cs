    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }
        // tell sqlite to ignore this column
        [Ignore]
        public int DaysLeft {
          get {
            // should add error handling here in case
            // date format is bad
            var date = DateTime.Parse(Date);
            // diff will be a TimeSpan
            var diff = DateTime.Now - date;
            // might want to add logic to handle negative values
            return diff.Days;
          }
        }
    }
