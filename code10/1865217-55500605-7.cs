    class MyController:Controller
    {
        DbContextWithAddProvider _ctxProvider;
        public MyController(DbContextWithAddProvider ctxProvider)
        {
            _ctxProvider=ctxProvider;
        }
        public async Task<IActionResult> Get()
        {
            var dbCtx=await _ctxProvider.GetContextAsync<MyDbContext>();
            ...
        }
    }
