    public class Category
    {
        public string name { get; set; }
        public Subcategory[] subcategories { get; set; }
    }
    public class Subcategory
    {
        public string name { get; set; }
        public Question[] questions { get; set; }
    }
    public class Question
    {
        public string question { get; set; }
        public string answer { get; set; }
        public string[] answers { get; set; }
    }
