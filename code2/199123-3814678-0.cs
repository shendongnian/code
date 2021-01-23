    public interface IInterface
    {
        bool interface_1 { get; set; }
    }
    public class MyClass : IInterface
    {
    }
    public class ReflectionHelper
    {
        private MyClass CreateByCopy(IInterface instance)
        {
            MyClass obj = new MyClass();
            foreach (PropertyInfo property in typeof( IInterface ).GetProperties())
            {
                property.SetValue( property, property.GetValue( instance, null ), null );
            }
            return obj;
        }
    }
