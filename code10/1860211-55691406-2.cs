    public class NotamViewModel  : INotifyPropertyChanged
    {
        protected readonly IEventAggregator _eventAggregator;
        public NotamViewModel(IEventAggregator ea)
        {
            _eventAggregator = ea;
         
            _eventAggregator.GetEvent<AirportSelectedEvent>()
             .Subscribe((_selectAirport) =>
             {
              this.SelectAirport = _selectAirport;
            
             });
        }
    }
