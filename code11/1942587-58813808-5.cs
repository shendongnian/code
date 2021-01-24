    public class HomeController : Controller
    {
        private const int DefaultPageSize = 10;
        private List<UserMovements> allMovements = new List<UserMovements>();
        public HomeController()
        {
            InitializeMovements();
        }
    
        private void InitializeMovements()
        {
            // Create a list of Movements. 
            for (var i = 0; i < 527; i++)
            {
                var userMovements = new UserMovements();
                userMovements.Name = "UserMovements " + (i + 1);
                var categoryIndex = i % 4;
                if (categoryIndex > 2)
                {
                    categoryIndex = categoryIndex - 3;
                }
                userMovements.Date = DateTime.Now.AddDays(i);
                allMovements.Add(userMovements);
            }
        }    
        public IActionResult ViewByDate(string startDate, string endDate, int? page)
        {
            string[] dates = { startDate, endDate };
            List<UserMovements> filtered;
            var currentPageNum = page.HasValue ? page.Value : 1;
            var offset = (DefaultPageSize * currentPageNum) - DefaultPageSize;
            var model = new ViewByDateViewModel();
            model.Date = dates ?? new string[0];
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            if (startDate == null && endDate == null)
            {
                filtered = this.allMovements.ToList();
            }
            else
            {
                filtered = this.allMovements
                    .Where(p => p.Date.Date >= DateTime.Parse(startDate) && p.Date.Date <= DateTime.Parse(endDate))
                    .ToList();
            }
            model.UserMovements.Data = filtered
                .Skip(offset)
                .Take(DefaultPageSize)
                .ToList();
            model.UserMovements.PageNumber = currentPageNum;
            model.UserMovements.PageSize = DefaultPageSize;
            model.UserMovements.TotalItems = filtered.Count;
            return View(model);
        }
    }
