    class Program
    {
        static void Main(string[] args)
        {
            MyClass<int> myClass = new MyClass<int>();
            string property1Name = myClass.Property1.GetPropertyName();
            string property2Name = myClass.Property2.GetPropertyName();
        }
    }
    public static class Extensions
    {
        public static string GetPropertyName<T>(this Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
    }
    
    public class MyClass<T>
    {
        public Expression<Func<T>> Property1; //Sample with MyClass being generic
        public Expression<Func<string>> Property2; //Sample which works anyway, MyClass being generic or not
    }
