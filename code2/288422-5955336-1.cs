        public class ProductProxy : Product
        {
            private IUnitOfWork _unitOfWork;
            public ProductProxy(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }  
 
            public Category Category
            {
                get
                {
                    // ...
                    var productRepo = _unitOfWork.CreateGenericRepo<Product>();
                    var categoryRepo = _unitOfWork.CreateGenericRepo<Category>();
                    // you can pull out the repos you need and work with them
                }
                set { ... }
            }
        }
