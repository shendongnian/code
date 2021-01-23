    static void Main(string[] args)
    {
        Program p = new Program();
        p.SomeMethod();
    }
    public class Fruit
    { }
    public class Apple : Fruit { }
    public delegate void FruitDelegate<in T>(T f) where T : Fruit;
    class Test
    {
        public static void Notify<T>(FruitDelegate<T> del)
            where T : Fruit, new()
        {
            T t = new T();
            del.DynamicInvoke(t);
        }
    }
    private void AppleHandler(Apple apple)
    {
        Console.WriteLine(apple.GetType().FullName);
    }
    public void SomeMethod()
    {
        FruitDelegate<Apple> del = new FruitDelegate<Apple>(AppleHandler);
        Test.Notify<Apple>(del);
    }
