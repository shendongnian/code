            var users = new[] { 
                new {
                    CompanyName = "c1",
                    Branch = "b3",
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
            var data = from u1 in users
                       group u1 by u1.CompanyName into gByCompanyName
                       select new
                       {
                           Node = gByCompanyName.Key,
                           Childs = from u2 in gByCompanyName
                                    group u2 by u2.Branch into gByBranch
                                    select new
                                    {
                                        Node = gByBranch.Key,
                                        Childs = from u3 in gByBranch
                                                 group u3 by u3.Destination into gByDestination
                                                 select new
                                                 {
                                                     Node = gByDestination.Key,
                                                     Childs = from u4 in gByDestination
                                                              select new { Node = u4.UserName }
                                                 }
                                    }
                       };
            foreach (var n1 in data)
            {
                Console.WriteLine(n1.Node);
                foreach (var n2 in n1.Childs)
                {
                    Console.WriteLine("\t" + n2.Node);
                    foreach (var n3 in n2.Childs)
                    {
                        Console.WriteLine("\t\t" + n3.Node);
                        
                        foreach (var n4 in n3.Childs)
                        {
                            Console.WriteLine("\t\t\t" + n4.Node);
                        }
                    }
                }
            }
            Console.ReadLine();
