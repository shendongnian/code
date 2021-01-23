    public interface ICar {
        // ...
    }
    public class Corvette : ICar {
        // ...
    }
    public void Foo() {
        Corvette mycar = new Corvette();
        // Now do a cast
        ICar = (ICar)mycar;
    }
