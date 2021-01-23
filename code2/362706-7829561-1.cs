    // aliased outside the namespace
    using MyList = System.Collections.Generic.List<Bar.FruitCallBack<Bar.Fruit>>;
    namespace Bar
    {
        // alternately, can be aliased inside the namespace 
        // using MyList = System.Collections.Generic.List<FruitCallBack<Fruit>>;        
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
