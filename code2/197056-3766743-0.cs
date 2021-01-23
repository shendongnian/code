    class Program
    {
        static void Main(string[] args)
        {
            Program.Do<Controller>(c => c.Save(1, "Jimmy"));
        }
        public static void Do<T>(Expression<Action<T>> expression) where T : Controller
        {
            var body = expression.Body as MethodCallExpression;
            if (body != null)
            {
                foreach (var argument in body.Arguments)
                {
                    var constant = argument as ConstantExpression;
                    if (constant != null)
                    {
                        Console.WriteLine(constant.Value);
                    }
                }
            }
        }
    }
    public class Controller
    {
        public void Save(int id, string name)
        {
        }
    }
