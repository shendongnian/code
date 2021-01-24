C#
//  I don't know how you're populating this list. I'm guessing that happens in 
//  compareStringList() and then you call FillDataGrid(). 
private List<string> Diff;
public ObservableCollection<CustomerInformation> CustomerInformationList { get; } 
    = new ObservableCollection<CustomerInformation>();
public void FillDataGrid()
{
    CustomerInformationList.Clear();
    foreach (var diff in Diff)
    {
        CustomerInformation TempCust = new CustomerInformation();
        TempCust.GetDiff = diff;
        CustomerInformationList.Add(TempCust);
    }
}
Now, let's use a binding to tell your DataGrid to use the collection property we created. Because you set `AutoGenerateColumns="True"` on your DataGrid, you don't need to create the columns yourself, but you had the binding , so I'm setting AutoGenerateColumns="False" and including the column definition. 
XAML
<DataGrid 
    ItemsSource="{Binding CustomerInformationList, RelativeSource={RelativeSource AncestorType=Window}}"
    AutoGenerateColumns="True" 
    HorizontalScrollBarVisibility="Visible" 
    Width="400" 
    x:Name="Differences" 
    Grid.Row="4" 
    Grid.ColumnSpan="3" 
    FontSize="16" Grid.Column="1"
    >
    <DataGrid.Resources>
        <!-- Stuff omitted -->
    </DataGrid.Resources>
    <DataGrid.Columns>
        <!-- 
        Each row is one item from CustomerInformationList. That means each row is an instance of
        CustomerInformation. CustomerInformation has a property named GetDiff, and here is how we 
        bind to that property. 
        -->
        <DataGridTextColumn 
            Header="Difference On Lines" 
            Binding="{Binding GetDiff}" 
            FontSize="16" 
            Width="200"
            />
    </DataGrid.Columns>
</DataGrid>
