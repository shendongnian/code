        public interface IProductController
        {
            Product GetByID(int id);
        }
    
        public class SomeProductController : IProductController
        {
            public Product GetByID(int id)
            {
                return << fetch code >> 
            }
        }
