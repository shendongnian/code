    public abstract class Fruit {
        public abstract T Match(Func<Apple, T> f, Func<Banana, T> g, Func<Grape, T> h);
    
        public class Apple {
            // apple properties
            public override T Match(Func<Apple, T> f, Func<Banana, T> g, Func<Grape, T> h) {
                return f(this);
            }
        }
        public class Banana {
            // banana properties
            public override T Match(Func<Apple, T> f, Func<Banana, T> g, Func<Grape, T> h) {
                return g(this);
            }
        }
        public class Grape {
            // grape properties
            public override T Match(Func<Apple, T> f, Func<Banana, T> g, Func<Grape, T> h) {
                return h(this);
            }
        }
    }
