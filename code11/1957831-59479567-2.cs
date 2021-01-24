        public static class DataContextExtensions
    {
        public static void EnsureSeedDataForContext(this AppDbContext context)
        {
        
        // first, clear the database.  This ensures we can always start fresh. This is optional ! 
            context.Games.RemoveRange(context.Games);
            context.SaveChanges();
            // init seed data
            var games = new List<Games>()
            {
                new Games()
                {
                     Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                     Name = "Stephen King",
                     Price= 14.99
                     Genre =  new Genre(),
                     Studio = new Studio(),
                }
            }
            //can seed other context data here
            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
