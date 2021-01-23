set
{
if (a != null)
{
 a.PropertyChanged-=NumberChanged;
}
 a = value;
 a.PropertyChanged+=NumberChanged;
 OnPropertyChanged("A");
 OnPropertyChanged("C");
}
private void NumberChanged(object sender, PropertyChangedEventArgs e)
{
  if (e.PropertyName == "Number")
  {
    OnPropertyChanged("C");
  }
}
