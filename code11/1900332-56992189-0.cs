    public void Print(List students) 
    {
        foreach (Student student in students)
        {
            if (student.Time =="4")
            {
                Console.WriteLine($"\nPeople who completed  graduation in 4 years : \n{student.Name}");
            }
            else
            {
                Console.WriteLine($"\nPeople who completed graduation in more or less than 4 years : \n{student.Name}\t{student.Time}");
            }
        }
    }
