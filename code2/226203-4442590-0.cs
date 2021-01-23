    public partial class CarListItem : UserControl
    {
        public CarListItem (Car car)
        {
            InitializeComponent();
    
            this.DataContext = car;
        }
    }
