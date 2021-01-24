        var userClients = from c in (dbContext joined tables)
          group c by c.UserName into u 
          select new {
              UserName = u.First().UserName,
              ClientName = string.Join(",", (from n in u select n.ClientName).ToArray()) 
          };
