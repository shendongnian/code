        static void Main(string[] args)
        {
            var ctx = new DbContext();
            //ctx.Database.EnsureCreated(); // you probably don't need this step
            var user = new PortalUser();
            var t = new RefreshToken("test", user.Id);
            user.RefreshToken = t;
            ctx.Users.Add(user);
            ctx.SaveChanges();
            
            var token = ctx.AspNetUserRefreshTokens.Find(t.Id);
            ctx.Entry(token).State = EntityState.Deleted;
            ctx.SaveChanges();
            var u = ctx.Users.Find(user.Id);
            Console.Write($"RefreshTokenId {u.RefreshTokenId}");
            Console.ReadKey();
        }
    }
