    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            TinyIoCContainer.Current.Register<INumber>(new NumberClass(42));
            TinyIoCContainer.Current.Register<MyClass>();
        }
    }
    public class MyClass
    {
        readonly INumber _number;
    
        public int MyClass(INumber number)
        {
             _number = number;
        }
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
