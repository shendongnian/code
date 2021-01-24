XAML
<Label Content="{Binding EmployeeName}" >
    <Label.Style>
        <Style TargetType="{x:Type Label}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ListViewItem}}" Value="True">
                    <Setter Property="Visibility" Value="Hidden"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Label.Style>
</Label>
<ComboBox Tag="{Binding ElementName=gdEmployee, Path=Tag}" ItemsSource="{Binding EmployeeList}" SelectedValue="{Binding SelectedEmployee.EmployeeID}" DisplayMemberPath="EmployeeName" SelectedValuePath="EmployeeID" FlowDirection="LeftToRight" Margin="15,5" HorizontalAlignment="Stretch" >
    <ComboBox.Style>
        <Style TargetType="{x:Type ComboBox}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ListViewItem}}" Value="False">
                    <Setter Property="Visibility" Value="Hidden"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </ComboBox.Style>
</ComboBox>
<hr/>
You should learn how to create and bind viewmodel properties, so here's that solution. First, we need to make the "viewmodel" an actual viewmodel:
C#
public class DailyServiceLogsViewModel : ViewModelBase
{
    public int DailyServiceLogID { get; set; }
    public int EmployeePositionID { get; set; }
    public PositionType SelectedEmployeePosition { get; set; }
    public List<PositionType> EmployeePositionList { get; set; }
    public List<EmployeeSelectionListViewModel> EmployeeList { get; set; }
    public EmployeeSelectionListViewModel SelectedEmployee { get; set; }
    public string EmployeeName { get; set; }
    public string PositionDescription { get; set; }
    public DateTime? Date { get; set; }
    public string WorkArea { get; set; }
    //  Only properties like this will notify the UI when they update. 
    private bool _isSelectedLog = false;
    public bool IsSelectedLog
    {
        get => _isSelectedLog;
        set => SetProperty(ref _isSelectedLog, value);
    }
}
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propName = null)
    {
        if (!Object.Equals(field, value))
        {
            field = value;
            OnPropertyChanged(propName);
        }
    }
}
Second, add an ItemContainerStyle that sets `IsSelectedLog` when when the item is selected. You can remove the SelectionChanged handler. 
XAML
<ListView ItemsSource="{Binding Items}">
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="IsSelected" Value="{Binding IsSelectedLog}" />
        </Style>
    </ListView.ItemContainerStyle>
    <ListView.View>
        <GridView>
            <GridViewColumn x:Name="clmServiceEmployeeName" Header="Employee" Width="155">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <Grid Tag="{Binding DailyServiceLogID}">
                            <Label Content="{Binding EmployeeName}" >
                                <Label.Style>
                                    <Style TargetType="{x:Type Label}">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding SelectedLog}" Value="True">
                                                <Setter Property="Visibility" Value="Hidden"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Label.Style>
                            </Label>
                            <ComboBox Tag="{Binding ElementName=gdEmployee, Path=Tag}" ItemsSource="{Binding EmployeeList}" SelectedValue="{Binding SelectedEmployee.EmployeeID}" DisplayMemberPath="EmployeeName" SelectedValuePath="EmployeeID" FlowDirection="LeftToRight" Margin="15,5" HorizontalAlignment="Stretch" >
                                <ComboBox.Style>
                                    <Style TargetType="{x:Type ComboBox}">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding SelectedLog}" Value="False">
                                                <Setter Property="Visibility" Value="Hidden"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </ComboBox.Style>
                            </ComboBox>
                        </Grid>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>
    </ListView.View>
</ListView>
