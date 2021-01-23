    private void button1_Click(object sender, EventArgs e)
    {  
      System.Collections.ArrayList alv = new System.Collections.ArrayList();
      int i = 0;
      private void button1_Click(object sender, EventArgs e)
      {
      OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=<<Your Database Path>>");
      OleDbCommand cmd=new OleDbCommand();
      for (int i = 0; i < dataGridView1.Rows.Count; i++)
      {
        DataGridViewRow MyRow = dataGridView1.Rows[i];
        if (MyRow.Selected == true)
        {
        dataGridView1.Rows.RemoveAt(i);
        try
        {
          conn.Open();
          //Here It Will Delete your Row From The Database Depending On Your Id....
          cmd.CommandText = "DELETE FROM MyTable Where Id=" + i + "";
          cmd.ExecuteNonQuery();
          conn.Close();
        }
        catch(Exception ex)
        {
          MessageBox.Show(ex.ToString());
        }
        }
      }
      }
    }
