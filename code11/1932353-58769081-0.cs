    public class SerialNumber
    {
        private static readonly MyDbContext DbContext = new MyDbContext();
        public static string SrNo()
        {
            var sn = DbContext.PrimaryForms.ToList().Last().FormDescription;
            var array = sn.Split('/');
            if (int.Parse(array[0]) == DateTime.Today.Year)
            {
                return array[0] + "/" + (int.Parse(array[1]) + 1);
            }
            return (int.Parse(array[0]) + 1) + "/1";
        }
    }
