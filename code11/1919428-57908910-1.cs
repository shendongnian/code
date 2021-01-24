    using(var context = new DbContext())
    {
         List<StudentWithSports> list = context
                                        .Students
                                        .Include(stu => stu.Actions)
                                        .Select(stu =>  new StudenWithSports
                                        {
                                            Name = stu.Name,
                                            Sports = stu.Actions.Select(act => act.SportName).ToList()
                                        }).ToList();
    }
