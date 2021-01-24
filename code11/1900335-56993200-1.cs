    public void Print2(List<Student> students)
            {
                var studentsIn4Years = students.Where(s => s.Time == 4).Select(s => s.Name);
                var studentsNotIn4Years = students.Where(s => s.Time == 4).Select(s => $"{student.Name}\t{student.Time}");
                
                Console.WriteLine($"\nPeople who completed  graduation in 4 years: ", string.Join(", ", studentsIn4Years));
                Console.WriteLine($"\nPeople who completed graduation in more or less than 4 years: ", string.Join(", ", studentsNotIn4Years));
            }
