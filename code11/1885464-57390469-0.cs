    DataTable PracticeTable= new DataTable();
    PracticeTable.Columns.Add("TestColumn1");
    PracticeTable.Columns.Add("");
    for (int i = 0; i < log.Count; i++)
    {
        PracticeTable.Rows.Add(log["" + i + ""][0], log["" + i + ""][1]);
    }
