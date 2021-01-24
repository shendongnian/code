    var list = context
               .Students
               .Include(stu => stu.Actions)
               .Select(stu =>  new {
                                     Name = stu.Name,
                                     Sports = stu.Actions.Select(act => act.SportName).ToList()
               }).ToList();
