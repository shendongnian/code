public static void SortStudents(IList<Student> students)
    {
        //We change this to Type Student, not string.
        Student temp;
        for (int i = 0; i < students.Count; i++)
        {
            for (int j = 0; j < students.Count; j++)
            {
                //We look at the Properties of the object, not the Object.ToString()  
                if (string.Compare(students[i].FirstName, students[j].FirstName) < 0)
                {
                    //Here we are swapping the objects, because we have determined 
                    //Their first names aren't in alphabetical order.  
                    temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                }
            }
        }
        Console.WriteLine(students);
    }
