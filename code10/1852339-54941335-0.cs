     public class Person
    {
        public List<Education> Educations = new List<Education>();
    }
    public class Education
    {
        public Enums.DegreeType Degree { get; set; }
    }
    public class Enums
            {
                public enum DegreeType
                {
                    Elementary_Education = 1,
                    High_School_Incomplete = 2,
                    High_School_Complete = 3,
                    Secondary_Technical_Or_Vocational = 5,
                    Vocational_Education_Student = 7,
                    Higher_Education_Institution__Student = 9
                }
            }
