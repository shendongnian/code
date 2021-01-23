    using System;
    enum FruitType
    {
        Apple,
        Banana,
        Pineapple,
    }
    interface IFruit
    {
        void Prepare();
        void Eat();
    }
    class Apple : IFruit
    {
        public void Prepare()
        {
            // Wash
        }
        public void Eat()
        {
            // Chew and swallow
        }
    }
    class Banana : IFruit
    {
        public void Prepare()
        {
            // Peel
        }
        public void Eat()
        {
            // Feed to your dog?
        }
    }
    class Pineapple : IFruit
    {
        public void Prepare()
        {
            // Core
            // Peel
        }
        public void Eat()
        {
            // Cut up first
            // Then, apply directly to the forehead!
        }
    }
    class FruitFactory
    {
        public IFruit GetInstance(FruitType fruitType)
        {
            switch (fruitType)
            {
                case FruitType.Apple:
                    return new Apple();
                case FruitType.Banana:
                    return new Banana();
                case FruitType.Pineapple:
                    return new Pineapple();
                default:
                    throw new NotImplementedException(
                        string.Format("Fruit type not yet supported: {0}"
                            , fruitType
                        ));
            }
        }
    }
    class Program
    {
        static FruitType AcquireFruit()
        {
            // Todo: Read this from somewhere.  A database or config file?
            return FruitType.Pineapple;
        }
        static void Main(string[] args)
        {
            var fruitFactory = new FruitFactory();
            FruitType fruitType = AcquireFruit();
            IFruit fruit = fruitFactory.GetInstance(fruitType);
            fruit.Prepare();
            fruit.Eat();
        }
    }
