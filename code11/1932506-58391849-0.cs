    public class StockRecord
    {
           ***
        public float ClosePrice { get; }
           ***
    }
    cfg.CreateMap<StockRecordDto, StockRecord>()
      .ConstructUsing(s => new StockRecord(s.TickerSymbol, s.TradingDay, s.OpenPrice, s.ClosePrice > 0 ? 100 : 200, s.DayHighestPrice, s.DayLowestPrice));
