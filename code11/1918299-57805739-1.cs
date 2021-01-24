xml
<TextBlock x:Name="TempBlock" />
**MainPage.xaml.cs**
csharp
private void Window_Loaded(object sender, RoutedEventArgs e)
{
    TemperatureInit();
}
private async void TemperatureInit()
{
    CurrentWeatherForecast currentWeatherForecast = new 
    CurrentWeatherForecast();
    var position = await LocationManager.GetPosition();
    string lat = position.Coordinate.Latitude.ToString();
    string lon = position.Coordinate.Longitude.ToString();
    var tempData = await currentWeatherForecast.GetCurrentWeather(lat, lon);
    // Assign a value directly to the TextBlock
    TempBlock.Text = tempData.temp;
}
---
## Update
Here is MVVM way:
**ViewModel**
csharp
public class WeatherViewModel : ViewModelBase, INotifyPropertyChanged
{
    CurrentWeatherForecast currentWeather;
    private string _temp;
    public string Temp
    {
        get { return _temp; }
        set
        {
            _temp = value;
            OnPropertyChanged();
        }
    }
    public WeatherViewModel()
    {
        currentWeather = new CurrentWeatherForecast();
    }
    private async void TemperatureInit()
    {
        CurrentWeatherForecast currentWeatherForecast = new 
        CurrentWeatherForecast();
        var position = await LocationManager.GetPosition();
        string lat = position.Coordinate.Latitude.ToString();
        string lon = position.Coordinate.Longitude.ToString();
        var tempData = await currentWeatherForecast.GetCurrentWeather(lat, lon);
        this.Temp = tempData.temp;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
**MainPage.xaml**
xml
<Page ...
    Loaded="Window_Loaded"
    >
    <Grid>
        <TextBlock Text={Binding Temp} />
    </Grid>
</Page>
**MainPage.xaml.cs**
csharp
public MainPage()
{
    this.InitializeComponent();
    this.DataContext = new WeatherViewModel();
}
private void Window_Loaded(object sender, RoutedEventArgs e)
{
    var vm = this.DataContext as WeatherViewModel;
    vm.TemperatureInit();
}
Among them, the `OnPropertyChanged` function is used to notify the UI to change the display when the data changes.
Best regards.
