    List<Student> students = new List<Student>();
    for(int i=0; i < 100; i++)
    {
      if (some condition)
      {
        Student s = new Student();
        s.ID = anotherIDlist[i]; //some value from another list;
        s.Name = anotherNamelist[i]; //some value from another list;
        students.Add(s);
      }
    }
