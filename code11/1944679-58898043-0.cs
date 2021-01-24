<ListView ItemsSource="{Binding xxx}" SelectedItem="{Binding SelectItem}" >
...
###in ViewModel
public class YourViewModel :INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
   
    private YourModel selectItem;
    public YourModel SelectItem
    {
        get
        {
            return selectItem;
        }
        set
        {
            if (selectItem!= value)
            {
                selectItem= value;
                NotifyPropertyChanged();
               double val = selectItem.Price;
               // do some thing you want here
            }
        }
    }
    //...
}
In your case , `Price` is the property of the model ,not the property of SelectedItem .Or you can improve your code like . But as I said ,use MVVM is better .
var SelectItem = e.SelectedItem as YourModel;
double val = SelectItem .Price;
