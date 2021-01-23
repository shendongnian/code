    public enum TypeQuestion {
       Long = 1,
       Short = 2,
       Small = 3,
    }
    
    public class QuestionViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int MaxAge { get; set; }
        public string Category { get; set; }
        public string Account { get; set; }
        public TypeQuestion CurrentTypeQuestion { get; set; }
    
        public bool EnabledField(ModelMetadata field)
        {
            //check pending implementation
            return true;
        }
    }
