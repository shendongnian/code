    public void Print(List students) 
    {
        var studentsIn4Years = students.Where(s => s.Time == "4");
        var studentsNotIn4Years = students.Where(s => s.Time != "4");
      
        // Do your logic here.
    }
