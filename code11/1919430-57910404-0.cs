          Student student1 = new Student
          {
                Name = "John",
                Actions = new List<Sport>
                {
                    new Sport { SportName = "Tennis" },
                    new Sport { SportName = "Soccer" },
                    new Sport { SportName = "Bowling" }
                }
            };
            Student student2 = new Student
            {
                Name = "Mary",
                Actions = new List<Sport>
                {
                    new Sport { SportName = "Tennis" },
                    new Sport { SportName = "Soccer" }                   
                }
            };
            Student student3 = new Student
            {
                Name = "Jane",
                Actions = new List<Sport>
                {
                    new Sport { SportName = "Tennis" }                    
                }
            };
            IEnumerable<Student> students = new List<Student>
            {
                student1,
                student2,
                student3
            };
            var query = from s in students
                        select new
                        {
                            s.Name,
                            Sports = from sp in s.Actions
                                     select sp.SportName
                        };
            var result = query.ToList();
           
            for (int i = 0; i < result.Count(); i++)
            {
                Console.Write(result[i].Name + " played sports: ");
                foreach (var sport in result[i].Sports)
                    Console.Write(" " + sport);
                Console.WriteLine();
            }
