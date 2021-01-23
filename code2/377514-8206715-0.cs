    public class Student : IComparable
    {
        private string name;
    
        public Student(string name)
        {
            this.name = name;
        }
    
        public int CompareTo(object other)
        {
            Student s = other as Student;
            if (s == null)
            {
                throw new ArgumentException("Students can only compare with other Students");
            }
    
            return this.name.CompareTo(s.name);
        }
    }
