    public class StudentProxy
    {
        private Student _student;
    
        public StudentProxy(Student student)
        {
            this._student = student;
        }
    
        public String School
        {
            get { return _student.School; }
            set
            {
                _student.School = value + "  my custom value";
            }
        }
    
        public String Country
        {
            get { return _student.Country; }
            set
            {
                _student.Country = value + "  my custom value";
            }
        }
    }
