XAML
<DataGrid
    ItemsSource="{Binding Selections}"
    AutoGenerateColumns="False"
    >
    <DataGrid.Resources>
        <Style TargetType="ComboBox" x:Key="GuildComboStyle">
            <!-- "property of ancestor control's DataContext" is how you get something 
            from a parent viewmodel -->
            <Setter 
                Property="ItemsSource" 
                Value="{Binding DataContext.Guilds, RelativeSource={RelativeSource AncestorType=DataGrid}}" 
                />
        </Style>
        <Style TargetType="ComboBox" x:Key="ChannelComboStyle">
            <Setter 
                Property="ItemsSource" 
                Value="{Binding DataContext.Channels, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                />
        </Style>
    </DataGrid.Resources>
    <DataGrid.Columns>
        <DataGridComboBoxColumn 
            Header="Guild"
            SelectedItemBinding="{Binding Guild}"
            DisplayMemberPath="Name" 
            ElementStyle="{StaticResource GuildComboStyle}"
            EditingElementStyle="{StaticResource GuildComboStyle}"
            />
        <DataGridComboBoxColumn 
            Header="Channel"
            SelectedItemBinding="{Binding Channel}"
            DisplayMemberPath="Name" 
            ElementStyle="{StaticResource ChannelComboStyle}"
            EditingElementStyle="{StaticResource ChannelComboStyle}"
            />
        <DataGridTextColumn Binding="{Binding Guild.SID}" Header="Guild SID" />
        <DataGridTextColumn Binding="{Binding Guild.Name}" Header="Guild Name" />
        <DataGridTextColumn Binding="{Binding Channel.CID}" Header="Channel CID" />
        <DataGridTextColumn Binding="{Binding Channel.Name}" Header="Channel Name" />
    </DataGrid.Columns>
</DataGrid>
C#
C#
public class MainViewModel
{
    public ObservableCollection<GuildSelection> Selections { get; set; }
    public ObservableCollection<Guild> Guilds { get; set; }
    public ObservableCollection<Guild.Channel> Channels { get; set; }
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
    private Guild.Channel _channel = null;
    public Guild.Channel Channel
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
}
public class Guild : ViewModelBase
{
    public class Channel
    {
        public string CID { get; set; }
        public string Name { get; set; }
    }
    public string SID { get; set; }
    public string Name { get; set; }
    //  I got rid of the Channels list here. If you want to give each of these its own 
    //  Channels list, that much simplifies the binding in the element styles above. 
    //  A GuildSelector is the row DataContext. If it has a Guild selected, bind to 
    //  the Channels property of the Guild. But then you can only select a channel after
    //  selecting a Guild. You might consider that desirable. 
    //  <Setter Property="ItemsSource" Value="{Binding Guild.Channels}" />
}
#region ViewModelBase Class
public class ViewModelBase : INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] 
        string propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    #endregion INotifyPropertyChanged
}
#endregion ViewModelBase Class
