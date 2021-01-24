    //datagrid to datatable
    DataTable datatable = new DataTable();
    datatable = (DataTable)dataGridView1.DataSource; 
    
    //datatableOrigin to hold your origin table
    DataTable originTable = null;
    // find Function
    Public void Find(string column, string st)
    {
        DataRow() dtResult;
        DataTable holder = New DataTable;
        DataTable holder = datatable.Clone();
        holder.Rows.Clear();
        If (originTable != null)
            datatable = originTable;
        Else
            originTable = datatable;
        //select return datarow array, thats
        dtResult = datatable.Select("[" & column & "] LIKE '%" & st & "%'");
        //import all your result into holder
        foreach(DataRow dr In dtResult){holder.ImportRow(dr);}
                
        //pass from holder to datatable
        datatable = holder.Copy();
        holder.Clear();
    }
    public void showDT()
    {
          dataGridView1.DataSource = datatable;
    }
    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string projektItem = 
        comboBox1.Items[comboBox1.SelectedIndex].ToString();
        
        Find('YourColumn, projektItem);
        showDT();
    }
