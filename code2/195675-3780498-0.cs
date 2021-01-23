    public abstract class Animal
    {
        private Animal() { } // prevents subclassing from outside!
        private sealed class Giraffe : Animal { }
        private sealed class Leopard : Animal { }
        public static Animal GetGiraffe( ) { return new Giraffe(); }
        public static Animal GetLeopard( ) { return new Leopard(); }
