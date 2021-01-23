    class Test
    {
        public delegate void FruitDelegate(Fruit f);
        public void Notify<T>(Action<T> del) where T : Fruit
        {
            FruitDelegate f = del; 
            f(new Banana());  //should be legal, but del may be Action<Apple>
        }
    }
