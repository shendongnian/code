    private void Form1_Load(object sender, EventArgs e) {
      allID();
      DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
      chk.HeaderText = "Select";
      chk.Name = "check";
      dtgId.Columns.Add(chk);
      dtgId.AllowUserToAddRows = false;
    }
    public void allID() {
      try {
        dtgId.DataSource = GetTable();
      }
      catch (SqlException ex) {
        MessageBox.Show("Error: " + ex.Message);
      }
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("ID", typeof(int));
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("CellPhone", typeof(string));
      for (int i = 0; i < 25; i++) {
        dt.Rows.Add(i, "name_" + i, "cellPhone_" + i);
      }
      return dt;
    }
    private void button2_Click(object sender, EventArgs e) {
      StringBuilder bloque = new StringBuilder();
      foreach (DataGridViewRow row in dtgId.Rows) {
        if (row.Cells["check"].Value != null && row.Cells["check"].Value.Equals(true)) {
          bloque.AppendLine("ID: " + row.Cells["ID"].Value + "\t" + row.Cells["Name"].Value + "\t" + row.Cells["CellPhone"].Value + "\t" + txtTexto.Text);
        }
      }
      // unclear what you want to do with bloque...?
      textBox1.Text += bloque.ToString();
      textBox1.Text += "---------------------------------------------" + Environment.NewLine;
    }
