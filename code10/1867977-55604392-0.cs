    [HttpGet]
        public virtual ActionResult Index()
        {
            List<NormPickerViewModel> viewModels = new List<NormPickerViewModel>();
    
            viewModels.Add(new NormPickerViewModel()
            {
                PickableNorms = new SelectList(
                    new List<dynamic> { new { Id = 1, Description = "Test1" }, new { Id = 2, Description = "Test2" } },
                    "Id",
                    "Description"
                )
            });
    
            viewModels.Add(new NormPickerViewModel()
            {
                PickableNorms = new SelectList(
                    new List<dynamic> { new { Id = 3, Description = "Test3" }, new { Id = 4, Description = "Test4" } },
                    "Id",
                    "Description"
                )
            });
    
            return View(viewModels);
        }
    
        [HttpPost]
        public virtual ActionResult Index(IEnumerable<NormPickerViewModel> normPickerViewModel)
        {
            // selectedNormList's count is always zero.
            return null;
        }
