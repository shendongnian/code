class RowDataComparer : IEqualityComparer<DataRow>
{
    public bool Equals(DataRow x, DataRow y)
    {
        var xv = x.ItemArray;
        var yv = y.ItemArray;
        for (int i = 0; i < xv.Length; i++)
            if (!xv[i].Equals(yv[i]))
                return false;
        return true;
    }
    public int GetHashCode(DataRow obj) 
        => obj.GetHashCode();
}
Assuming that schema is identical, keys are integers and you don't care about extra/missing rows you can use something like below:
class RowsComparer
{
    Dictionary<int, DataRow > _leftRows;
    Dictionary<int, DataRow > _rightRows;
    HashSet<int> _commonKeys;
    private static Dictionary<int, DataRow>  toRows(DataTable table)
        => table.Rows.OfType<DataRow>().ToDictionary(r => (int)r.ItemArray[0]);
    public RowsComparer(DataTable left, DataTable right)
    {
        _leftRows = toRows(left);
        _rightRows = toRows(right);
        _commonKeys = new HashSet<int>(_leftRows.Keys.Intersect(_rightRows.Keys));
    }
    public IEnumerable<DataRow> Diffs()
        => _commonKeys.Select(k => _rightRows[k]).Except(_leftRows.Values, new RowDataComparer());
}
