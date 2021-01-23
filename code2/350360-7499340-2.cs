     internal static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            private static void Main()
            {
                var fact = new FactoryA();
                int passParam = 5;//fromGUI
                ProductA f = fact.Create(passParam);
            }
        }
    
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
    
        public abstract class Factory<T> where T : ProductBase
        {
            public abstract T Create(int passedParam);
        }
    
        public class FactoryA : Factory<ProductA>
        {
            public override ProductA Create(int passedParam)
            {
                return new ProductA() { x = 1, y = 1, z = passedParam };
            }
        }
    
        public class FactoryB : Factory<ProductB>
        {
            public override ProductB Create(int passedParam)
            {
                return new ProductB() { x = 1, y = 1, a = passedParam };
            }
        }
