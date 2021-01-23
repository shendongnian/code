    User user;
    using (var ctx = new Model1Container())
    {
               
        user = ctx.UserSet
                   .Include("Employee")
                   .Include("Employee.Photo")
                   .Include("Employee.Telefon")
                   .Single(x => x.Id == id);  
    }
    Console.Out.WriteLine(user.UserName);
    Console.Out.WriteLine(user.Employee.Telefon.First().Number);
    Console.ReadLine();
