    public class PJAwardsService
    {
        public static List<PJAwards> GetAll()
        {
            using (var context = new YourDBEntities())
            {
                return context.PJAwards
                    .Include(x => x.PJUsers)
                    .Include(x => x.PJUsers1)
                    .Include(x => x.PJAwartypes).ToList();
            }
        }
    }
