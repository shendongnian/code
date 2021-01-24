      [HttpGet]
      public async Task<IActionResult> Index()
      {
           var viewModel = new IndexViewModel(){
              PersistantMessagesPartialModel = new 
              PersistantMessagesPartialModel(){
                    Messages = await 
               _AppUserDBContext.userList.ToListAsync()
                };
          return View(viewModel);
       }
