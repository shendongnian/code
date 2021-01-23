    public class TestData:  INotifyPropertyChanged
    {
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            this.NotifyPropertyChanged("Name");
        }
    }
    // I only included one property for simplicity.  You of course will need to do this
    // for every property in the test model
    public event PropertyChangedEventHandler PropertyChanged;
    
    private void NotifyPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
