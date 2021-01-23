    public struct Result
    {
        public Result(ActionType action,  Boolean success, ErrorType error)
        {
            this.Action = action;
            this.HasSuceeded = success;
            this.Error = error;
        }
        public ActionType Action { get; private set; }
        public Boolean HasSuceeded { get; private set; }
        public ErrorType Error { get; private set; }
    }
    
        public enum ErrorType
        {
            InvalidProductName, InvalidProductType, MaxProductLimitExceeded, None,
            InvalidCategoryName // and so on 
        }
    
        public enum ActionType
        {
            CreateProduct, UpdateProduct, DeleteProduct, AddCustomer // and so on
        }
    
        public class ProductBLL
        {
            public Result CreateProduct(String type, String name, Int32 id)
            {
                Boolean success = false;
                // try to create the product
                // and set the result appropriately
                // could create the product without errors?
                success = true;
    
                return new Result(ActionType.CreateProduct, success, ErrorType.None);
            }
        }
