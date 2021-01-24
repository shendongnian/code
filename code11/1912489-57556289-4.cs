    class Program
    {
        static void Main(string[] args)
        {
            Seed();
            var _context = new SchoolContext();
            var list = _context.MySet("ConsoleAppEF.Student").ToList1();
        }
    
        private static void Seed()
        {
            var _context = new SchoolContext();
            var students = new List<Student>
            {
                new Student{FirstMidName="Carson",LastName="Alexander"},
            };
    
            students.ForEach(s => _context.Students.Add(s));
            _context.SaveChanges();
        }
    }
