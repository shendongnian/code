    public class CategoryWithNoDeletedItems : Category
    {
        private ICollection<Product> _products;
        public override ICollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                if (value.Any(x => x.IsDeleted))
                {
                    _products = value.Where(x => !x.IsDeleted).ToArray();
                }
                else
                {
                    _products = value;
                }
            }
        }
    }
