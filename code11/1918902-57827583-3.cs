    static void Main()
    {
        Student student1 = new Student
        {
            FirstName = "John",
            Lastname = "Park",
            Grade = 60
        };
        Student student2 = new Student
        {
            FirstName = "Joe",
            Lastname = "Doe",
            Grade = 80
        };
        Student student3 = new Student
        {
            FirstName = "Rose",
            Lastname = "Hancook",
            Grade = 90
        };
        student1.PrintStudentInfo();
        Console.ReadKey();
    }
