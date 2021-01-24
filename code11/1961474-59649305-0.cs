    class Student
    {
        public int Id {get; set;}
        ... // other properties
        // Every student speaks zero or more Languages (many-to-many)
        public virtual ICollection<Language> Languages {get; set;}
    }
    class Language
    {
        public int Id {get; set;}
        ... // other properties
        // Every Language is spoken by zero or more Students(many-to-many)
        public virtual ICollection<Student> Students {get; set;}
    }
