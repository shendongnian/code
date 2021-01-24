    string badColumnsString = "";
    for(int i = 0; i < badColumns.Length; i++)
    {
        badColumnsString += badColumns[i].ToString() + " ";
    }
    badColumnsString = badColumnsString.TrimEnd(' ');
    MessageBox.Show(badColumnsString);
