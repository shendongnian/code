    public enum Gender
    {
        Male,
        Female
    }
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private string myGender = Gender.Male.ToString();
        public string MyGender
        {
            get
            {
                return myGender;
            }
            set
            {
                myGender = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("MyGender"));
                }
            }
        }
        public string[] Genders
        {
            get
            {
                return Enum.GetNames(typeof(Gender));
            }
        }
        public Window1()
        {
            InitializeComponent();
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
      }
