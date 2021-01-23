    public class QuestionViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<ConditionalField> ConditionalFields { get; set; }
        public string Category { get; set; }
        public string Account { get; set; }
    }
    
    public class ConditionalField
    {
       public string Field { get; set; }
       public bool Display { get; set; }
    }
