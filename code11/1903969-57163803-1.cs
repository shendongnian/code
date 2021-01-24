    var users = File.ReadAllLines(filepath).Select(x=>
        { 
            var line = x.Split(;);
            return new User
                {
                    FirstName = line[0],
                    LastName = line[1],
                    Password = line[2]
                }
        }).ToList();
