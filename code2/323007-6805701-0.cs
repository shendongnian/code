    public class FruitFactory<T> : FactoryBase<T> where T : Fruit, new()
    {        
        // I'm assuming this is in FactoryBase<T>
        public override T CreateInstance()
        {
            return new T();
        }
    }
