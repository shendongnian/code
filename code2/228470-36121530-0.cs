    ....
    //ctx = dataContext class - not shown here.
    var user1 = new UserData() { User = 1, Age = 2, Data = 43.5 };
    var user2 = new UserData() { User = 2, Age = 3, Data = 44.5 };
    var user3 = new UserData() { User = 3, Age = 4, Data = 45.6 };
    ctx.UserData.AddRange(new List<UserData> { user1, user2, user3 });
    var growth1 = new UserGrowth() { Id = 1, Age = 2, Growth = 46.5 };
    var growth2 = new UserGrowth() { Id = 1, Age = 5, Growth = 49.5 };
    var growth3 = new UserGrowth() { Id = 1, Age = 6, Growth = 48.5 };
    ctx.UserGrowth.AddRange(new List<UserGrowth> { growth1, growth2, growth3 });
    var query = from userData in ctx.UserData
                            join userGrowth in ctx.UserGrowth on userData.Age equals userGrowth.Age
                                into joinGroup
                            from gr in joinGroup.DefaultIfEmpty()
                            select new
                            {
                                User = userData.User,
                                age = userData.Age,
                                Data = (double?)userData.Data,
                                Growth = (double?)gr.Growth
                            };
    Console.WriteLine("{0} | {1} | {2} | {3}", "User", "age", "Data", "Growth");
                foreach (var x in query)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3}", x.User, x.age, x.Data, x.Growth);
                }
    .... with following entity classes:
      
    public class UserData
        {
            [Key]
            public int User { get; set; }
            public int Age { get; set; }
            public double Data { get; set; }
        }
        public class UserGrowth
        {
            public int Id { get; set; }
            public int Age { get; set; }
            public double Growth { get; set; }
        }
