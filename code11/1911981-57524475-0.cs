<Frame IsVisible="{Binding IsVisible}"  Padding="10,5" CornerRadius="5" HasShadow="False">
   //...
                                
</Frame>
>in your model
public class Model : INotifyPropertyChanged
{
  public string Comments { get; set; }
  public event PropertyChangedEventHandler PropertyChanged;
        
  protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
  {
     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
  private bool isvisible;
  public bool IsVisible
  {
    get
    {
       return isvisible;
    }
    set
    {
      if (isvisible != value)
      {
         isvisible = value;
         NotifyPropertyChanged();
      }
     }
 }
        //...other property
}
And you can set the value of it.For example ,if you want to set all frame `isVisible` as `false`
foreach(var model in MyItems)
{
  model.IsVisible = false;
}
**MyItems** is the `ItemsSource` of listview . Don't forget init the property when you init the ItemsSource .Otherwise the value of `IsVisible` is `false` in default.
