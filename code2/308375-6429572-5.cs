    foreach(var grade in grades)
    {
      //You could always use a foreach here too
      for(int i = 0; i < grade.StudentNames.Length ; i++)
      {
        Console.WriteLine(grade.StudentNames[i]);
      }
    }
