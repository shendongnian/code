    public class OracleStoredProcedures
    {
        private const string ProductPackageName = "DATABASE.PRODUCT_PKG";    
        private const string AddressPackageName = "DATABASE.ADDRESS_PKG";
        public const string GetAllProductsById = ProductPackageName + ".GET_ALL_PRODUCTS_BY_ID";
        public const string GetLatestProducts = ProductPackageName + ".GET_LATEST_PRODUCTS";
        public const string GetAddressById = AddressPackageName + ".GET_ADDRESS_BY_ID";
    }
