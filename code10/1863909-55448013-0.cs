cs
public class WeekDay
{
    public DateTime Date { get; }
    public string Day { get; }
    public bool IsToday { get; }
    public WeekDay(DateTime date)
    {
        this.Date = date;
        this.Day = date.DayOfWeek.ToString();
        this.IsToday = date.Date == DateTime.Today;
    }
}
<ItemsControl.ItemTemplate >
    <DataTemplate>
        <Border BorderBrush="{StaticResource GrayBrush7}"
                BorderThickness="1,0,0,0"
                SnapsToDevicePixels="True"
                UseLayoutRounding="True">
            <Border.Style>
                <Style TargetType="Border">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsToday}" Value="True">
                            <Setter Property="Background" Value="Yellow" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Border.Style>
...
As an alternative, you can use ValueConverter to convert Date to Background.
cs
public class DateToItemBackgroundConverter : IValueConverter
{
    private static readonly Brush TodayBGBrush = new SolidColorBrush(Colors.Yellow);
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is DateTime))
        {
            return value;
        }
        var isToday = ((DateTime)value).Date == DateTime.Today;
        return isToday ? TodayBGBrush : null;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
<ItemsControl Grid.Column="1"
              Focusable="False" 
              ItemsSource="{Binding WeekDays}">
    <ItemsControl.Resources>
        <local:DateToItemBackgroundConverter x:Key="bgConverter" />
    </ItemsControl.Resources>
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <StackPanel Orientation="Horizontal"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
    <ItemsControl.ItemTemplate >
        <DataTemplate>
            <Border BorderBrush="{StaticResource GrayBrush7}"
                    Background="{Binding Date, Converter={StaticResource bgConverter}}"
                    BorderThickness="1,0,0,0"
                    SnapsToDevicePixels="True"
                    UseLayoutRounding="True">
...
Remember if you wanna refresh background when TODAY is updated, you should rebuild model data or notify PropertyChanged again.
