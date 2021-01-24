    public interface IObeyOrder
    {
        [Order(2)]
        [Order(4)]
        void Method1(); // should run 2nd or 4th
        [Order(1)]
        void Method2(); // 1st
        [Order(3)]
        void Method3(); // 3rd
        void Method4(); // order doesn't matter
    }
