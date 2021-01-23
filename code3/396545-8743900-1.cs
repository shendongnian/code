    private DataTable m_MyDataSource = new DataTable();
    
    private void button1_Click(object sender, EventArgs e)      
    {
          string tokNum = this.textBox1.Text;
          if (this.textBox1.Text != "")
          {
              DataRow newRow = m_MyDataSource.NewRow();
              newRow[2] = tokNum;
              m_MyDataSource.AddRow(newRow);
          }
    }  
