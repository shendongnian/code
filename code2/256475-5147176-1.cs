    public class Product {
        // no one can "make" Products
        private Product(IDataRecord dr) {
            // Make this product from the contents of the IDataRecord
        }
    
        static private List<Product> GetList(string sp, Action<DbCommand> addParameters) {
            List<Product> lp = new List<Product>();
            // DAL.Retrieve yields an iEnumerable<IDataRecord> (optional addParameters callback)
            // public static IEnumerable<IDataRecord> Retrieve(string StoredProcName, Action<DbCommand> addParameters)
            foreach (var dr in DAL.Retrieve(sp, addParameters) ) {
                lp.Add(new Product(dr));
            }
            return lp;
        }
    
        static public List<Product> AllProducts() {
            return GetList("sp_AllProducts", null) ;
        }
    
        static public List<Product> AllProductsStartingWith(string str) {
            return GetList("sp_AllProductsStartingWith", cm => cm.Parameters.Add("StartsWith", str)) ;
        }
    
        static public List<Product> AllProductsOnOrder(Order o) {
            return GetList("sp_AllProductsOnOrder", cm => cm.Parameters.Add("OrderId", o.OrderId)) ;
        }
    }
