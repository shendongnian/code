    var students = new List<Student>();
    for (int i = 0; i < 50; i++)
    {
        students.Add(new Student { Id = i, Name = $"Student { i }" });
    }
    var sectionedStudents = students.Select(s => new
    {
         GroudId = s.Id / 10,
         s.Id,
         s.Name
    });
    var groupedStudents = sectionedStudents.GroupBy(s => s.GroudId);
