    public class POSViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed Event Handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ObservableCollection<TicketModel> _Tickets { get; set; }
        public ObservableCollection<TicketModel> Tickets {
            get {
                return _Tickets;
            }
            set {
                _Tickets = value;
                OnPropertyChanged(nameof(Tickets));
            }
        }
        public POSViewModel() {
            Tickets = new ObservableCollection<TicketModel>();
        }
        public void Add() {
            TicketModel Ticket = new TicketModel
            {
                ImageSource = @"H:\Good.png",
                Prix = 10,
                TicketId = 0
            };
            Tickets.Add(Ticket);
        }
    }
    
    public class TicketModel
    {
        private int ticketId;
        private float prix;
        private string imageSource;
        private ImageSource imageTicket;
        public int TicketId { get; set; }
        public float Prix { get; set; }
        public string ImageSource { get; set; }
    }
