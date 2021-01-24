      public BaseController(ModelContext context /* as well as other injections */)
        {
          _db = context;
        }
        internal ModelContext _db;
