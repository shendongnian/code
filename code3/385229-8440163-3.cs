    using Extensions;
    
    ...
    string msg = string.Empty;
    foreach (var item in gridView1.GetColumnsDistinctDisplayText("columnName"))
    {
        msg += item + "\n";
    }
    MessageBox.Show(msg);
