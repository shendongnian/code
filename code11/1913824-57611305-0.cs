<Label Text="Pin is requored!"  TextColor="Red"  HorizontalTextAlignment="Center" IsVisible="{Binding isVisible}"/>
<Button Text="sign in" BackgroundColor="Red" TextColor="White" Command="{Binding ClickCommand}"  WidthRequest="200" />
###in your ViewModel
public class YourViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public ICammand ClickCommand {get; set;}
    private bool isvisible;
    public bool isVisible
    {
     get
     {
        return isvisible;
     }
     set
     {
      if (isvisible!= value)
      {
        isvisible= value;
        NotifyPropertyChanged();
      }
    }
    public YourViewModel()
    {
        //... 
        isVisible = true; //show the label in default
         
        ClickCommand = new Command(() =>
        {
           if(xxx)
           {
              isVisible =false;
           }
           
           else
           { 
              isVisible =true;
           }
        }) ;
    }
}
