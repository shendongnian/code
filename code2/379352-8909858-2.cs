    public class Person
    {
        public int Age
        {
            get
            {
                // ToDo: better algorithm to determine real age is left as an exercise to the reader. ;-)
                var age = (int)((DateTime.Now - Born).TotalDays / 365);
                return Math.Max(0, age);
            }
        }
        public DateTime Born { get; set; }
        public string FirstName { get; set; }
        public int Index { get; set; }
        public string LastName { get; set; }
    }
