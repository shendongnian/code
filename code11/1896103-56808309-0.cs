C#
public class A
{
    public B instanceB1 { get; set; }
    public B instanceB2 { get; set; }
}
public class B
{
    public A instanceA { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
}
Then bind to them:
XAML
<DataGrid
    ItemsSource="{Binding Items}"
    AutoGenerateColumns="False"
    >
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding instanceB1.Min}" Header="B1.Min" />
        <DataGridTextColumn Binding="{Binding instanceB1.Max}" Header="B1.Max" />
        <DataGridTextColumn Binding="{Binding instanceB2.Min}" Header="B2.Min" />
        <DataGridTextColumn Binding="{Binding instanceB2.Max}" Header="B2.Max" />
    </DataGrid.Columns>
</DataGrid>
