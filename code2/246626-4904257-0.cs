    class Student {
        public string Name { get; set; }
        public int Number { get; set; }
    
        public Student (string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
    
    
    var students = new List<Student> {
        new Student ("Daniel", 10),
        new Student ("Mike", 20),
        new Student ("Ashley", 42)
    };
    
    var nameToRemove = Console.ReadLine ();
    students.RemoveAll (s => s.Name == nameToRemove); // remove by condition
