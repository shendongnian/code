    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Status 
        {
           get { return Age >= 18 ? "Adult" : "Under age"; }
        }
        public override string ToString()
        {
           return string.Format("{0}|{1}|{2}",Name,Age,Status);
        }
    }
