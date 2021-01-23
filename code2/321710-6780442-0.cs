    public interface ITradingApiTrader
    {
        ITradingApi CreateMT4TradingApi();
        ITradingApi CreateFooTradingApi();
        ITradingApi CreateBarTradingApi();
        // etc.
    }
