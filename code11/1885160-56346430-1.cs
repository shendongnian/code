private int? _a;
public int? A
{
   get => _a;
   set
   {
       if (value.HasValue != _a.HasValue || value.GetValueOrDefault(0) != _a.GetValueOrDefault(0))
       {
          _a = value;
          OnPropertyChanged();
          OnPropertyChanged("C");
       }
   }
 }
private int? _b;
public int? B
{
    get => _b;
    set
    {
       if (value.HasValue != _b.HasValue || value.GetValueOrDefault(0) != _b.GetValueOrDefault(0))
       {
          _a = value;
          OnPropertyChanged();
          OnPropertyChanged("C");
       }
    }
 }
 public int? C
 {
    get => A + B;
 }
 public event PropertyChangedEventHandler PropertyChanged;
 [NotifyPropertyChangedInvocator]
 protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
 {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
 }
