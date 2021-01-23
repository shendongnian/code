    public class ProductBase
    {
        public int x;
        public int y;
    }
    
    public class ProductA : ProductBase
    {
        public int z;
    }
    
    public class ProductB : ProductBase
    {
        public int a;
    }
    public class Factory
    {
        abstract Product Create();
    }
    public class FactoryA:Factory
    {
        override Product Create()
        {
             return new ProductA();
        }
    }
    public class FactoryB:Factory
    {
        override Product Create()
        {
           return new ProductB();
        }
    }
