        public abstract class Fruit { }
        public class Apple : Fruit { }
        public class Pear : Fruit { }
        public class LunchBox<A>
            where A : Fruit
        {
            public A FruitSnack { get; set; }
        }
        public class LunchBox<A, B> : LunchBox<A>
            where A : Fruit 
            where B : Fruit
        {
            public B ExtraFruitSnack { get; set; }
        }
        var myLunchBox = new LunchBox<Apple>();
 
        var myBiggerLunchBox = new LunchBox<Apple, Pear>();
