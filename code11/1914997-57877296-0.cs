namespace QuantConnect 
{
    public class ConsolidatorAlgorithm : QCAlgorithm
    {
        private readonly Resolution _resolution = Resolution.Hour;
        private readonly string _ticker = "ETHUSD";
        private readonly int _startingCash = 2000;
        private readonly int _fastPeriod = 12;
        private ExponentialMovingAverage _fastEmaCustomTimeFrame;
        private ExponentialMovingAverage _fastEmaStandardResolution;
        private string _baseSymbol;
        public override void Initialize()
        {
            SetStartDate(2017, 1,1);  //Set Start Date
            SetEndDate(2017, 1, 2);    //Set End Date
            SetCash(_startingCash);    //Set Strategy Cash
            QuantConnect.Securities.Crypto.Crypto crypto = AddCrypto(_ticker, _resolution);
            _baseSymbol = crypto.BaseCurrencySymbol;
            SetBrokerageModel(BrokerageName.Bitfinex, AccountType.Cash);
            TradeBarConsolidator consolidator = new TradeBarConsolidator(TimeSpan.FromHours(1));
            SubscriptionManager.AddConsolidator(_ticker, consolidator);
            consolidator.DataConsolidated += OnCustomHandler;
            // use constructor for ExponentialMovingAverage instead of QCAlgorithm#EMA
            _fastEmaCustomTimeFrame = new ExponentialMovingAverage(_fastPeriod);
            _fastEmaStandardResolution = EMA(_ticker, _fastPeriod, _resolution);
            RegisterIndicator(_ticker, _fastEmaCustomTimeFrame, consolidator);
            var history = History<TradeBar>(_ticker, 12);
            foreach (var bar in history) {
                _fastEmaCustomTimeFrame.Update(bar.EndTime, bar.Close);
                _fastEmaStandardResolution.Update(bar.EndTime, bar.Close);
            }
        }
        public void OnCustomHandler(object sender, TradeBar data)
        {
            if (!_fastEmaCustomTimeFrame.IsReady && !_fastEmaStandardResolution.IsReady) {
                return;
            }
            Log($"ema custom time frame: {_fastEmaCustomTimeFrame}");
        }
        public void OnData(TradeBars data) 
        {
            if (!_fastEmaCustomTimeFrame.IsReady && !_fastEmaStandardResolution.IsReady) {
                return;
            }
            Log($"ema standard time resolution: {_fastEmaStandardResolution}");
        }
    }
}
