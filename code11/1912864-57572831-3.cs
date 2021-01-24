    public class ClassA
    {
        public ClassA()
        {
            Marks = new StudentMarks();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public StudentMarks Marks { get; set; }
    }
    
    public class StudentMarks
    {
        public int Marks { get; set; }
        public string Grade { get; set; }
    }
