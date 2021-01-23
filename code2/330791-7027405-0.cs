    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IUser>().ConditionallyUse(cond =>
                {
                    cond.TheDefault.Is.Type<MyUser>();
                    cond.If(ctx =>
                    {
                        var hasContext = false;
                        try
                        {
                            hasContext = HttpContext.Current == null;
                        }catch
                        {
                            // HttpContext.Current sometimes throws when there isn't one
                        }
                        return hasContext;
                    }).ThenIt.IsThis(new MyUser.None());
                });
            });
    
            var instance = ObjectFactory.GetInstance<IUser>();
            Console.WriteLine(instance.GetType());
        }
    
        public interface IUser{}
        public class MyUser : IUser { public class None : IUser {} }
    }
