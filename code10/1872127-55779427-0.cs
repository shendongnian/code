    public class MyDbContext : DbContext
    {
        [DbFunction]
        public static int AddHours(DataTime source, int hours)
        {
            // don't need any implementation
            throw new Exception();
        }
    }
