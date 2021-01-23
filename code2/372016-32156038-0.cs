    public class StudentsBuilder
    {
        private int _size;
        private IList<string> _firstNames; 
        private IList<string> _lastNames;
        private IList<MentorBuilder> _mentors;
        
        public StudentsBuilder(int size = 10)
        {
            _size = 10;
            _firstNames = new RandomStringGenerator(size).Generate();
            _lastNames = new RandomStringGenerator(size).Generate();
            _mentors = Enumerable.Range(0, size).Select(_ => new MentorBuilder()).ToList();
        }
        public StudentsBuilder WithFirstNames(params string[] firstNames)
        {
            _firstNames = firstNames;
            return this;
        }
        public IList<Student> Build()
        {
            students = new List<Student>();
            for (int i = 0; i < size; i++)
                students.Add(new Student(_firstNames[i], _lastNames[i], _mentors[i].Build());
            return students;
        }
    }
