    public enum enumA : int
    {
        item1 = 0,
        item2 = 1,
        item3 = 2
    }
    public enum Day
       { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
    public class PassACustomDataTypeFController : Controller
    {
        public ActionResult Index()
        {
            bool b1 = CheckIfPresent<enumA>(5);
            bool b2 = CheckIfPresent<Day>(5);
            return View();
        }
        private bool CheckIfPresent<T>(object val) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Wrong argument");
            }
            var expr = Expression.Call(typeof(Enum).GetMethod("IsDefined", new Type[] { typeof(Type), typeof(object) }), 
                                       Expression.Constant(typeof(T)),
                                       Expression.Convert(Expression.Constant(val),
                                                          typeof(object)
                                                          )
                                       );
            var retVal = Expression.Lambda<Func<bool>>(expr).Compile()();
            return retVal;
        }
    }
