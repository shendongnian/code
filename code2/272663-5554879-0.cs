    var students = new List<Student>();
    for(int i=0; i < 100; i++)
    {
        if (some condition)
        {
            // You can produce the student to add any way you like, e.g.:
            someStudent = new Student { ID = anotherIDlist[i], Name = anotherNamelist[i] };
            students.Add(someStudent);
        }
    }
