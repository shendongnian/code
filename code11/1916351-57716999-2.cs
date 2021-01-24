XAML
<DataGrid
    ItemsSource="{Binding Selections}"
    AutoGenerateColumns="False"
    Grid.Row="1"
    >
    <DataGrid.Resources>
        <Style TargetType="ComboBox" x:Key="GuildComboStyle">
            <Setter 
                Property="ItemsSource" 
                Value="{Binding DataContext.Guilds, RelativeSource={RelativeSource AncestorType=DataGrid}}" 
                />
        </Style>
        <Style 
            TargetType="ComboBox" 
            x:Key="ChannelComboStyle"
            >
            <Setter  Property="ItemsSource" Value="{Binding Guild.Channels}" />
            <Style.Triggers>
                <Trigger Property="HasItems" Value="False">
                    <Setter Property="IsEnabled" Value="False" />
                </Trigger>
                <DataTrigger Binding="{Binding Guild}" Value="{x:Null}">
                    <Setter Property="IsEnabled" Value="False" />
                    <Setter Property="IsEditable" Value="True" />
                    <Setter Property="Text" Value="Select a Guild" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </DataGrid.Resources>
    <DataGrid.Columns>
        <DataGridComboBoxColumn 
            Header="Guild"
            SelectedItemBinding="{Binding Guild, UpdateSourceTrigger=PropertyChanged}"
            DisplayMemberPath="Name" 
            ElementStyle="{StaticResource GuildComboStyle}"
            EditingElementStyle="{StaticResource GuildComboStyle}"
            Width="200"
            />
        <DataGridComboBoxColumn 
            Header="Channel"
            SelectedItemBinding="{Binding Guild.Channel, UpdateSourceTrigger=PropertyChanged}"
            DisplayMemberPath="Name" 
            ElementStyle="{StaticResource ChannelComboStyle}"
            EditingElementStyle="{StaticResource ChannelComboStyle}"
            Width="200"
            />
        <DataGridTextColumn Binding="{Binding Guild.SID}" Header="Guild SID" />
        <DataGridTextColumn Binding="{Binding Guild.Name}" Header="Guild Name" />
        <DataGridTextColumn Binding="{Binding Guild.Channel.CID}" Header="Channel CID" />
        <DataGridTextColumn Binding="{Binding Guild.Channel.Name}" Header="Channel Name" />
    </DataGrid.Columns>
</DataGrid>
C#
C#
public class MainViewModel
{
    public ObservableCollection<GuildSelection> Selections { get; set; }
    public ObservableCollection<Guild> Guilds { get; set; }
    public ObservableCollection<Channel> Channels { get; set; }
}
public class GuildSelection : ViewModelBase
{
    #region Guild Property
    private Guild _guild = null;
    public Guild Guild
    {
        get { return _guild; }
        set
        {
            if (value != _guild)
            {
                _guild = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion Guild Property
}
public class Channel
{
    public string CID { get; set; }
    public string Name { get; set; }
}
public class Guild : ViewModelBase
{
    public string SID { get; set; }
    public string Name { get; set; }
    public List<Channel> Channels { get; set; }
    #region Channel Property
    private Channel _channel = null;
    public Channel Channel
    {
        get { return _channel; }
        set
        {
            if (value != _channel)
            {
                _channel = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion Channel Property
}
#region ViewModelBase Class
public class ViewModelBase : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(
        [System.Runtime.CompilerServices.CallerMemberName] string propName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    #endregion INotifyPropertyChanged
}
#endregion ViewModelBase Class
