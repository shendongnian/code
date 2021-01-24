    // group by the first column
    var groupsOfDuplicates = dt.Rows.Cast<DataRow>().GroupBy(row => row[0]); 
    // for each group
    foreach (var groupOfDuplicateRows in groupsOfDuplicates)
    {
        // Skip the first, let's just erase the others
        foreach (var duplicateRow in groupOfDuplicateRows.Skip(1))
        {
            duplicateRow[1] = DBNull.Value;
            duplicateRow[2] = DBNull.Value;
        }
    }
