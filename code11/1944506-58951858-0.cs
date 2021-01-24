public class MyViewModel : Conductor<object>.Collection.AllActive 
{
    //the user control property where MainContent = new OtherViewModel()
    private IScreen _mainContent;
    public IScreen MainContent
    {
        get { return _mainContent; }
        set 
        {
            _mainContent = value;
            NotifyOfPropertyChange(() => MainContent);
        }
    }
}
In MyView in XAML:
<ContentControl x:Name="MainContent"/>
The `Items` property in the ViewModel is instead just used to manage the lifecycle of the active windows. I was able to use multiple `<ContentControl x:name="ViewModelProperty">` to place custom user controls as needed and dynamically.
