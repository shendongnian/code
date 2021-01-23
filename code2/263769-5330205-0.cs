    public class Class
    {
        IList<Student> _students;
        public IList<Student> Students
        {
            get
            {
                if(_students == null)
                {
                    _students = new IList<Student>();
                    PopulateStudents(); // just for simplicity
                }
            }
            // no need for a setter usually... Use Students.Add(Student s)
        }
    }
 
