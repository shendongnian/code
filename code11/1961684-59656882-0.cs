    public class Student { public string Name { get; set; } public int Age { get; set; } }
    public class Program
    {
        public static List<Student> Students = new List<Student>();
        public static void CreateStudents()
        {
            for (var i = 0; i < 1000000; i++)
            {
                Students.Add(new Student {Name = $"Student{i}", Age = i});
            }
        }
        public static List<Student> WhereManualOriginal(List<Student> students)
        {
            var filteredList = new List<Student>();
            for (var i = 0; i < students.Count(); i++)
            {
                var student = students[i];
                if (student.Age == 32)
                {
                    filteredList.Add(student);
                }
            }
            return filteredList;
        }
        public static List<Student> WhereManualNew(List<Student> students)
        {
            var filteredList = new List<Student>();
            for (var i = 0; i < students.Count; i++)
            {
                if (students[i].Age == 32)
                {
                    filteredList.Add(students[i]);
                }
            }
            return filteredList;
        }
        public static long LinqWhere()
        {
            var sw = Stopwatch.StartNew();
            var items = Students.Where(s => s.Age == 32);
            foreach (var item in items) { }
            sw.Stop();
            return sw.ElapsedTicks;
        }
        public static long ManualWhere()
        {
            var sw = Stopwatch.StartNew();
            var items = WhereManualOriginal(Students);
            foreach (var item in items) { }
            sw.Stop();
            return sw.ElapsedTicks;
        }
        public static long NewManualWhere()
        {
            var sw = Stopwatch.StartNew();
            var items = WhereManualNew(Students);
            foreach (var item in items) { }
            sw.Stop();
            return sw.ElapsedTicks;
        }
        public static void Main()
        {
            // Warmup stuff
            CreateStudents();
            WhereManualOriginal(Students);
            WhereManualNew(Students);
            Students.Where(s => s.Age == 32).ToList();
            var linqResults = new List<long>();
            var manualResults = new List<long>();
            var newManualResults = new List<long>();
            for (int i = 0; i < 100; i++)
            {
                newManualResults.Add(NewManualWhere());
                manualResults.Add(ManualWhere());
                linqResults.Add(LinqWhere());
            }
            Console.WriteLine("Linq where ......... " + linqResults.Average());
            Console.WriteLine("Manual where ....... " + manualResults.Average());
            Console.WriteLine("New Manual where ... " + newManualResults.Average());
            GetKeyFromUser("\nDone! Press any key to exit...");
        }
    }
