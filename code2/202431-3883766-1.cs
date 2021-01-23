    public ObservableCollection<Seat> SeatCollection {get;set;}
    
    public ViewModelConstructor()
    {
       TheaterSeatingEntities entities = new TheaterSeatingEntities();
       SeatCollection = new ObservableCollection<Seat>(entities.Seats);
    }
