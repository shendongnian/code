        // Simulating a db
        private List<Country> Countries;
        public HomeController()
        {
            // Initializing sample data
            Countries = new List<Country>();
            Countries.Add(new Country() { countryId = 1, countryName = "USA" });
            Countries.Add(new Country() { countryId = 2, countryName = "England" });
            Countries.Add(new Country() { countryId = 3, countryName = "Japan" });
            Countries.Add(new Country() { countryId = 4, countryName = "China" });
        }
        public ActionResult Index()
        {
            // I prefer using the ViewData Dictionary for my selectlists
            ViewData["CountrySelectList"] = new SelectList(Countries, "countryId", "countryName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(CountryViewModel cvModel)
        {
            var country = Countries.First(c => c.countryId == cvModel.CountryId);
            // Do Stuff Like Saving and Updating
            ViewData["CountrySelectList"] = new SelectList(Countries, "countryId", "countryName");
            return View(cvModel);
        }
