    dynamic student = new ExpandoObject();
    student.FirstName = "John";
    student.LastName = "Doe";
    student.Introduction = new Action(() => Console.WriteLine("Hello my name is {0} {1}", student.FirstName, student.LastName));
    Console.WriteLine(student.FirstName);
    student.Introduction();
    student.FirstName = "changed";
    Console.WriteLine(student.FirstName);
    student.Introduction();
