    public class Course
    {
        private ICollection<Student> _students;
    
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfStudents { get; set; }
    
        public ICollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
    
                _students = value;
                NumberOfStudents = _students?.Count ?? 0;
            }
        }
    }
