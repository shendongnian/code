    // Code not tested, blah blah blah...
    public class FooController : Controller
    {
        private static readonly ConcurrentDictionary<string, string[]> _cache
            = new ConcurrentDictionary<string, string[]>();
    
        private readonly IFoo _foo;
        public FooController(IFoo foo)
        {
            _foo = foo;
        }
    
        public ActionResult PewPew()
        {
            var files = _cache.GetOrAdd(Server.MapPath(_foo.PathToFiles), path => {
                return Directory.GetFiles(path);
            });
            
            return View(files);
        }
    }
