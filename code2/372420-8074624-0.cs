     class Theatre
        {
            public Theatre(int numberOfSeats)
            {
                NumberOfSeats = numberOfSeats;
            }
            public int NumberOfSeats { get; private set; }
        }
    
        class Show
        {
            List<Seats> listOfSeats = new List<Seats>();
          
            public Show(Theatre theatre)
            {
                for (int i = 0; i < theatre.NumberOfSeats; i++) //  <---- And here is my problem!!
                {
                    //Code to add to list
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Theatre myTheatre = new Theatre(100);
                Show myShow = new Show(myTheatre);
            }
        }
