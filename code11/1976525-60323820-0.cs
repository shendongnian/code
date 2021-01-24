public static string[,] SkipBlankRows(string[,] array2D)
{
    var columns = array2D.GetLength(1);
    var rows = array2D.GetLength(0);
    var temp = Enumerable.Range(0, rows)
        .Select(i => Enumerable.Range(0, columns).Select(j => array2D[i, j]).ToList())
        .Where(row => !row.All(string.IsNullOrEmpty))
        .ToList();
    string[,] result = new string[temp.Count, columns];
    rows = temp.Count();
    for (int r = 0; r < rows; r++)
    {
        var row = temp[r];
        for (var c = 0; c < row.Count; c++)
        {
            result[r, c] = row[c];
        }
    }
    return result;
}
Of course, if you're willing to bring in a couple of helper methods to abstract away the conversion to and from rows, you can end up with a highly efficient and very easy-to-read code.
- https://stackoverflow.com/q/27427527/120955
- https://stackoverflow.com/q/26291609/120955
