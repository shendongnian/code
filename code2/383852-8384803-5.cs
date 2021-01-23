    public class ProductFactory : EntityFactory, IProductFactory
    {
        #region IProductFactory Members
    
        public Product Get(string productId)
        {
            Product p = null;
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandText = "select * from product where productId = :productId";
                    cmd.Parameters.Add("productId", productId);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        p = new Product();
                        p.MapData(reader);
                    }
                }
            }
            return p;
        }
    
        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    
    
        public int GetAllCount()
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
