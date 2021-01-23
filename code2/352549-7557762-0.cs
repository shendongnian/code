     //for the view
    partial class MainView:Window
     {
             InitializeComponent();
             this.DataContext=new MainViewModel();
     }
    //ViewModel Code
 
    public class MainViewModel: INotifyPropertyChanged
    {
      //INotifyPropertyChanged implementation
      public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    //bindable property
    private bool _football;
    public bool Football
    {
        get { return _football; }
        set
        {
            if (value != _football)
            {
                _football = value;
                this.OnPropertyChanged("Football");
            }
        }
    }
    //... and the same for Golf and Hockey
    }`
