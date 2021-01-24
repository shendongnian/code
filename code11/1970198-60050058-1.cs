    public class ServiceManualsController : Controller
    {
        private readonly MVC2Context _context;
        public ServiceManualsController(MVC2Context context)
        {
            _context = context;
        }
            // GET: ServiceManuals
        public List<ServiceManual> Index()
        {
            var Category = new int[] { 1,2,3};
            var classtime = PredicateBuilder.True<ServiceManual>();
            for (int i = 0; i < Category.Length; i++)
            {
                long? cateID = Convert.ToInt64(Category[i]);
                if (Category.Length == 1)
                {
                    classtime = classtime.And(c => c.Id == cateID);
                }
                else
                {
                    classtime = classtime.Or(c => c.Id == cateID);
                }
            }
            var lstclasssCate = _context.tblServiceManual.Where(classtime.Compile()).ToList();
            return lstclasssCate;
        }
