c#
public class SettingsPropertyValueProxy : INotifyPropertyChanged
{
    public string Name { get; }
    public Type PropertyType => PropertyValue.GetType();
    public object PropertyValue
    {
        get
        {
            return Properties.Settings.Default[Name];
        }
        set
        {
            try
            {
                Properties.Settings.Default[Name] = Convert.ChangeType(value, PropertyType);
                Properties.Settings.Default.Save();
            }
            catch
            { }
        }
    }
    public SettingsPropertyValueProxy(string name)
    {
        Name = name;
        Properties.Settings.Default.PropertyChanged += (sender, e) => _OnPropertyChanged(e.PropertyName);
    }
    private void _OnPropertyChanged(string propertyName)
    {
        if (propertyName == Name) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PropertyValue)));
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
**New Property to bind:**
c#
public IEnumerable<SettingsPropertyValueProxy> Values { get; } 
    = Properties.Settings.Default.Properties
    .Cast<SettingsProperty>()
    .Select(p => new SettingsPropertyValueProxy(p.Name))
    .OrderBy(p => p.Name)
    .ToArray();
**Correct View and Correct DataTemplates:**
xml
<ListView Grid.Row="1"
        ItemsSource="{Binding Path=Values}"
        HorizontalContentAlignment="Stretch" Background="LightGray"
        ScrollViewer.HorizontalScrollBarVisibility="Disabled">
    <ListView.ItemTemplate>
        <DataTemplate>
            <DockPanel HorizontalAlignment="Stretch"
                    IsEnabled="{Binding DataContext.Enabled, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}}}">
                <Label Width="200" Content="{Binding Path=Name}"/>
                <Label Width="200" Content="{Binding Path=PropertyType}" Foreground="Gray" FontStyle="Italic"/>
                <!--<TextBox Text="{Binding Path=PropertyValue, Mode=TwoWay}"/>-->
                <ContentControl VerticalContentAlignment="Center" Content="{Binding Path=PropertyValue}">
                    <ContentControl.Resources>
                        <ResourceDictionary>
                            <DataTemplate DataType="{x:Type sys:Boolean}">
                                <CheckBox IsChecked="{Binding Path=PropertyValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" 
                                            DataContext="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DockPanel}}, Path=DataContext}"/>
                            </DataTemplate>
                            <DataTemplate DataType="{x:Type sys:String}">
                                <TextBox Text="{Binding Path=PropertyValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                            DataContext="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DockPanel}}, Path=DataContext}"/>
                            </DataTemplate>
                            <DataTemplate DataType="{x:Type sys:Int32}">
                                <TextBox Text="{Binding Path=PropertyValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                            DataContext="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DockPanel}}, Path=DataContext}"/>
                            </DataTemplate>
                        </ResourceDictionary>
                    </ContentControl.Resources>
                </ContentControl>
            </DockPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
  [1]: https://stackoverflow.com/a/57300798/1121245
