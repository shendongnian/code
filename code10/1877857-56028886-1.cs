    namespace Common.Aggregator
    {
    
        public class BaseTimeAggregator
        {
                    
            // REMOVE this field    
            // --> private Bar _workingBar;
    
            
            private readonly object _lock = new object();
            private readonly Dictionary<int, Bar> _barDictionary = new Dictionary<int, Bar>();
    
    
    
            private void OnBarEvent(Object source, System.Timers.ElapsedEventArgs e)
            {
                var bar = (Bar)source;
                
                // Manipulate with the actual instance defined in 'bar'-variable ..
            }
    
            public void Update(Tick data)
            {
                lock (_lock) {          
                  AggregateBar(data);
                }
            }
    
            public void Smth_method(int barId)
            {
                lock (_lock) {          
                    var bar = _barDictionary[uniqueBarId];
                    // ..
                }
            }
    
            protected void AggregateBar(Tick data)
            {
              var uniqueBarId = data.{some param that identify bar};
    
              if (_barDictionary.ContainsKey(uniqueBarId)) {
                _barDictionary[uniqueBarId].Update(data.DataType, data.LastPrice, data.BidPrice, data.AskPrice, data.Volume, data.BidSize, data.AskSize);
                return;
              }
    
              var bar = new Bar(data.LastPrice, data.LastPrice, data.LastPrice, data.LastPrice);
              bar.PreClosePrice = data.PreClosePrice;
            
              _barDictionary[uniqueBarId] = bar;           
            }
    
        }
    }
