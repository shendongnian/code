    var users = lines.Select(line=>new User
            {
                FirstName = line[0],
                LastName = line[1],
                Password = line[2]
            }).ToList();
