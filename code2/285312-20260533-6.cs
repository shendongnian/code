    {
       public string Name { get; set; }
       public float grade { get; set; }
       public static void failed(List<Student> studentList, isFaild fail)
       {
           foreach (Student student in studentList)
           {
              if(fail(student))
              {
        Console.WriteLine("Sorry" + " "+student.Name + " "+  "you faild this exam!");
              }
           }
       }
