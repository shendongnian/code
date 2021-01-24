    // Add the table.
    Word.Table tbl = rng.Tables.Add(rng, 13, 2, ref missing, ref missing);
    //Define a range from the start of doc to new table
    Word.Range rngDocToTable = tbl.Range;
    rng.Start = doc.Content.Start;
    int nrTablesInRange = rng.Tables.Count;
    //Get index of previous table
    int indexPrevTable = nrTablesInRange - 1;
    Word.Table previousTable = null;
    if (indexPrevTable > 0)
    {
        previousTable = doc.Tables[indexPrevTable];
    }
    else
    {
        System.Windows.Forms.MessageBox.Show("No previous tables");
    }
