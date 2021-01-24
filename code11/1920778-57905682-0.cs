 csharp
public abstract class ViewModelBase : INotifyPropertyChanged
{
    /* INotifyPropertyChanged implementation +
       whatever other common behavior makes sense
       belongs in this class
    */
}
public class MainViewModel : ViewModelBase
{
    public WeatherViewModel Weather { get; } = new WeatherViewModel();
    public ForecastViewModel Forecast { get; } = new ForecastViewModel();
    public DeparturesViewModel Departures { get; } = new DeparturesViewModel();
    public CalendarViewModel Calendar { get; } = new CalendarViewModel();
}
In your view code behind file you're setting the data context to 2 different instances of MainViewModel - once in the constructor and once in the Loaded event handler. I'd stick with the constructor version or instead you could set the data context in XAML like this:
 xaml
<MainPage.DataContext>
    <MainViewModel>
</MainPage.DataContext>
Once the data context for the main page is setup and the view models are public properties then you can use bindings to access the state (properties) of the view models perhaps something like this:
 xaml
<TextBlock Text='{Binding Path=Weather.CurrentTempCelsius, StringFormat='Current Temp: {0}°C'}' />
