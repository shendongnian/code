     class Program
     {
         static void Main(string[] args)
         {
             List<Student> list = new List<Student>()
                {
                 new Student() { Id = 1, Name = "Student 1", OtherInformation = new Dictionary<string, string>()
                                             {
                                                 { "hobby", "Music" },
                                                 { "Score",  "50" }
                                             }
                                         },
                 new Student() { Id = 2, Name = "Student 2", OtherInformation = new Dictionary<string, string>()
                                             {
                                                 { "hobby", "Golf" },
                                                 { "Score",  "70" }
                                             }
                                         },
                 new Student() { Id = 3, Name = "Student 3", OtherInformation = new Dictionary<string, string>()
                                             {
                                                 { "hobby", "Archery" },
                                                 { "Score",  "30" }
                                             }
                                         }
             };
    
             Console.WriteLine(list.OrderBy(x => x.OtherInformation["Score"]).FirstOrDefault().Name);
             Console.Read();
          }
     }
