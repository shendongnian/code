    public interface IConfigHelper
    {
        string MyProperty { get; set; }
    }
    
    public class ConfigHelper : IConfigHelper
    {
        public string MyProperty { get; set; }
    }
    
    public interface IMyService
    {
    
    }
    
    public class MyServiceImpl : IMyService
    {
        public MyServiceImpl(string myArg)
        {
    
        }
    }
    
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigHelper>()
                .To<ConfigHelper>()
                .WithPropertyValue("MyProperty", "foo");
        }
    }
    
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            var helper = Kernel.Get<IConfigHelper>();
            Bind<IMyService>()
                .To<MyServiceImpl>()
                .WithConstructorArgument("myArg", helper.MyProperty);
        }
    }
    
    class Program
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel(
                new HelperModule(),
                new ServiceModule()
            );
    
            var service = kernel.Get<IMyService>();
        }
    }
