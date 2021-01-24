        Public void Find(string column, string)
    {
        DataRow() dtResult;
        DataTable holder = New DataTable
        DataTable holder = datatable.Clone()
        holder.Rows.Clear()
        If (originTable != null)
            datatable = originTable
        Else
            originTable = datatable
        dtResult = datatable.Select("[" & column & "] LIKE '%" & st & "%'")
        foreach(DataRow dr In dtResult){holder.ImportRow(dr)}
                
        datatable = holder.Copy()
        holder.Clear()
    }
    public void showDT()
    {
          dataGridView1.DataSource = datatable;
    }
