            var users = new[] { 
                new {
                    CompanyName = "c1",
                    Branch = "b1",
                    Destination = "d1",
                    UserName= "u1",
                },                new {
                    CompanyName = "c1",
                    Branch = "b1",
                    Destination = "d1",
                    UserName= "u1",
                },                new {
                    CompanyName = "c1",
                    Branch = "b1",
                    Destination = "d1",
                    UserName= "u1",
                },                new {
                    CompanyName = "c2",
                    Branch = "b1",
                    Destination = "d2",
                    UserName= "u2",
                },
            };
            var data = from u in users
                       group u by u.CompanyName into ug
                       select new { Node = ug.Key, Childs = ug };
            foreach (var i in data)
            {
                Console.WriteLine(i.Node);
                foreach (var node in i.Childs)
                {
                    Console.WriteLine("\t" + node.UserName);
                }
            }
