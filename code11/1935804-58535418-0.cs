    private void btnConvertItemsToCheckedRows_Click(object sender, EventArgs e)
    {
      if(  ListBox1.ListBox.Items.Count>0)
      {
        for (int i = 0; i <ListBox1.ListBox.Items.Count; i++)
        {
          foreach (DataGridViewRow row in GridStudents.DataGridView.Rows)
          {
            if(row.Cells["StudentCode"].Value.ToString().Equals(ListBox1.ListBox.Items[i]))
            {
              DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ChekboxColumn"];
              chk.Value = chk.TrueValue;
            }
          }
        }
        GridStudents.EndEdit();
      }
    }
