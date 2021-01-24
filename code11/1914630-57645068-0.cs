    public interface Foo<T, U> {
        void foobar (T first, U second);
    }
    
    public class Bar implements Foo {
        void foobar (T first, U second) {
            //Stuff
        }
    }
    
    //Use this like....
    Bar bar = new Bar<Double, Decimal>
