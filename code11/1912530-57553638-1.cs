 c#
private void Button1_Click(object sender, EventArgs e)
{
    List<string> eSplit = new List<string>(eInputBox.Text.Split(new string[] { "," }, StringSplitOptions.None));
    DataGridViewTextBoxColumn eOutputGrid = new DataGridViewTextBoxColumn();
    eOutputGrid.HeaderText = "Section";
    eOutputGrid.Name = "Section";
    eOutputDGV.Columns.Add(eOutputGrid);
    eOutputGrid = new DataGridViewTextBoxColumn();
    eOutputGrid.HeaderText = "Letters";
    eOutputGrid.Name = "Letters";
    eOutputDGV.Columns.Add(eOutputGrid);
    eOutputGrid = new DataGridViewTextBoxColumn();
    eOutputGrid.HeaderText = "Numbers";
    eOutputGrid.Name = "Numbers";
    eOutputDGV.Columns.Add(eOutputGrid);
    foreach (string item in eSplit)
    {
        eOutputDGV.Rows.Add(item.Trim(), item.Trim().Substring(0, 3), item.Trim().Substring(3));
    }
}
