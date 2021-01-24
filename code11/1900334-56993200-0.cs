    public void Print(List<Student> students)
    {
        var studentsIn4Years = new List<string>();
        var studentsNotIn4Years = new List<string>();
        foreach (var student in students)
        {
            if (student.Time == "4")
            {
                studentsIn4Years.Add(student.Name);
            }
            else
            {
                studentsNotIn4Years.Add($"{student.Name}\t{student.Time}");
            }
        }
        Console.WriteLine($"\nPeople who completed  graduation in 4 years: ", string.Join(", ", studentsIn4Years));
        Console.WriteLine($"\nPeople who completed graduation in more or less than 4 years: ", string.Join(", ", studentsNotIn4Years));
    }
