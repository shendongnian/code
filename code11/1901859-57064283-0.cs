    public class DbModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int clientId { get; set; }
        public static List<DbModel> GetModels()
        {
            return new List<DbModel>()
            {
                new DbModel()
                {
                    first_name = "Andrew",
                    last_name = "Clyde",
                    clientId = 1590
                },
                new DbModel()
                {
                    first_name = "Andrew",
                    last_name = "Clyde",
                    clientId = 0
                },
                new DbModel()
                {
                    first_name = "David",
                    last_name = "Jeffrey",
                    clientId = 0
                }
            };
        }
    }
    public class DbViewModel
    {
        public string full_name { get; set; }
        public List<int> clientIds { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<DbModel> dbModels = DbModel.GetModels();
            List<DbViewModel> viewModels = dbModels.GroupBy(x => x.first_name.ToLower() + ' ' + x.last_name.ToLower()).Select(fullNameGrouping =>
                new DbViewModel()
                {
                    full_name = fullNameGrouping.Key,
                    clientIds = fullNameGrouping.Select(x => x.clientId).ToList()
                }).ToList();
            Console.ReadKey();
        }
    }
