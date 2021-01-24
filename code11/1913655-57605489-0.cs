public event PropertyChangedEventHandler PropertyChanged;
protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
{
  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
private bool isconnecting ;
public bool isConnecting
{
  get
  {
    return isconnecting;
  }
  set
  {
    if (isconnecting != value)
    {
      isconnecting = value;
      NotifyPropertyChanged();
    }
  }
}
