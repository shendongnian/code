    public class ViewModel1
    {
        private readonly IEventAggregator _eventService;
        private Car _selectedCar;
        public ViewModel1(IEventAggregator eventService)
        {
            _eventService = eventService;
        }
        //Databound property...
        public Car SelectedCar
        {
            set
            {
                _selectedCar = value;
                var msg = new CarSelectedMessage { Car = _selectedCar };
                _eventService.GetEvent<CarSelectedEvent>().Publish(msg);
            }
        }
    }
    public class ViewModel2
    {
        public ViewModel2(IEventAggregator eventService)
        {
            eventService.GetEvent<CarSelectedEvent>().Subscribe(msg =>
            {
                //DoStuff with msg...
            });
        }
    }
    public class Car {}
    public class CarMessage
    {
        public Car Car { get; set; }
    }
    public class CarSelectedEvent : CompositePresentationEvent<CarMessage> {}
