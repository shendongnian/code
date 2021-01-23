    public interface ITradingApi
    {
        Object CreateOrder();
        IEnumerable<Object> GetAllSymbols();
    }
    
    public class TradingApi : ITradingApi
    {
        IvisitorAPI _VisitorAPI;
    
        public TradingApi(IvisitorAPI visitorAPI)
        {
            _VisitorAPI = visitorAPI;
        }
    
    
        public Object CreateOrder()
        {
            var Order = new Object();
            //bla bla bla
    
            //here code relative to different visitor
            _VisitorAPI.SaveOrder(Order);
    
            return Order;
        }
    }
