    using MyList = System.Collections.Generic.List<Bar.FruitCallBack<Bar.Fruit>>;
    namespace Bar
    {
        class Program
        {
            static void Main()
            {
                var myList = new MyList();
            }
        }
    
        public class FruitCallBack<T> { }
        public class Fruit { }
    }
