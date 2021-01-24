class Helper
{
public void AddColumn(Grid grid, string name)
{
 grid.Columns.Add(new GridColumn(name));
}
}
this does not store reference on grid or gridcolumn instance so GC is not affected
