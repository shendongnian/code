for(int i = 0; i< DataGridView.Rows.Count; i++)
{
    DataGridViewCell colPhone1 = DataGridView.Rows[i].Cells["Phone1"];
    DataGridViewCell colPhone2 = DataGridView.Rows[i].Cells["Phone2"];
    if(colPhone1.Value == null || colPhone1.Value == DBNull.Value)
    {
        colPhone1.Value = colPhone2.Value;
        colPhone2.Value = DBNull.Value;
    }
    else if(colPhone2.Value == null || colPhone2.Value == DBNull.Value)
    {
        colPhone2.Value = colPhone1.Value;
        colPhone1.Value = DBNull.Value;
    }
}
