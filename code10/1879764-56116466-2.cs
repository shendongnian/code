    public class MyController
    {
      private readonly BloggingContext _context;
      public MyController(BloggingContext context)
      {
        _context = context;
      }
      ...
    }
