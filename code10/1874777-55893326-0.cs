    public class OracleStoredProcedures
    {
        private static readonly string ProductPackageName = "DATABASE.PRODUCT_PKG";    
        private static readonly string AddressPackageName = "DATABASE.ADDRESS_PKG";
        public static readonly string GetAllProductsById = $"{ProductPackageName}.GET_ALL_PRODUCTS_BY_ID";
        public static readonly string GetLatestProducts = $"{ProductPackageName}.GET_LATEST_PRODUCTS";
        public static readonly string GetAddressById = $"{AddressPackageName}.GET_ADDRESS_BY_ID";
    }
