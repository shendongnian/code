C#
public class A
{
    public B instanceB1 { get; set; }
    public B instanceB2 { get; set; }
    public IEnumerable<B> EnumerateLeaves
    {
        get
        {
            foreach (var child in instanceB1.EnumerateLeaves
                                      .Concat(instanceB2.EnumerateLeaves))
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
    public IEnumerable<B> EnumerateLeaves
    {
        get
        {
            if (instanceA == null)
            {
                yield return this;
            }
            else
            {
                foreach (var child in instanceA.EnumerateLeaves)
                    yield return child;
            }
        }
    }
}
Then bind to them:
XAML
<DataGrid
    ItemsSource="{Binding TreeRootItem.EnumerateLeaves}"
    AutoGenerateColumns="False"
    >
    <DataGrid.Columns>
        <DataGridTextColumn Binding="{Binding Min}" Header="Min" />
        <DataGridTextColumn Binding="{Binding Max}" Header="Max" />
    </DataGrid.Columns>
</DataGrid>
