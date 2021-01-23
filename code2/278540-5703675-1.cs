    List<StudentGrade> l = new List<StudentGrade>();
    int LastId = -1;
    foreach (var grade in Grades)
    {
        if (grade.Id == LastId || LastId == -1)
        {
            // add this item to the list
            l.Add(grade);
        }
        else
        {
            // New student. Output data for previous student.
            if (l.Count == 3)
            {
                // output this student.
            }
            else
            {
                // student not output because not all grades are in.
            }
            LastId = grade.Id;
            l.Clear();
            l.Add(grade);
        }
    }
    // Check last student
    if (l.Count == 3)
    {
        // output last student
    }
    else
    {
        // don't output because not all grades are in
    }
    }
