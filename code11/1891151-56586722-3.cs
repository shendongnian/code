    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            // Register DI
            TinyIoCContainer.Current.Register<INumber>(new NumberClass(42));
            TinyIoCContainer.Current.Register<MyClass>();
            // Resolve DI
            var myClass = TinyIoCContainer.Current.Resolve<MyClass>();
            Console.Writeline(myClass.ToString()); //42
            
        }
    }
    public class MyClass
    {
        readonly INumber _number;
    
        public int MyClass(INumber number)
        {
             _number = number;
        }
        public override ToString() => _number.Num;
    }
    public class NumberClass : INumber
    {
        public NumberClass(int number)
        {
            Num = number;
        }
     
        public int Num { get; }
    }
    public interface INumber
    {
        int Num { get; }
    }
