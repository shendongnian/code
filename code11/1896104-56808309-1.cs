C#
public class A
{
    public B instanceB1 { get; set; }
    public B instanceB2 { get; set; }
    public IEnumerable<B> Enumerate
    {
        get
        {
            foreach (var child in instanceB1.Enumerate.Concat(instanceB2.Enumerate))
            {
                yield return child;
            }
        }
    }
}
public class B
{
    public A instanceA { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public IEnumerable<B> Enumerate
    {
        get
        {
            if (instanceA == null)
            {
                yield return this;
            }
            else
            {
                foreach (var child in instanceA.Enumerate)
                    yield return child;
            }
        }
    }
}
Then bind to them:
XAML
<DataGrid
    ItemsSource="{Binding TreeRootItem.Enumerate}"
    AutoGenerateColumns="False"
    >
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding Min}" Header="Min" />
        <DataGridTextColumn Binding="{Binding Max}" Header="Max" />
    </DataGrid.Columns>
</DataGrid>
