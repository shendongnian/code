    public class Student
    {
        public string Id { get; set; }
        public string Mark { get; set; }
        // Required to make to have the list box display useful information about students.
        public override string ToString()
        {
            return $"Id = {Id}, Mark = {Mark}";
        }
    }
