    private void viewinfo_Click(object sender, EventArgs e){
        dataGridView1.Visible = true;
        OleDbCommand cmd;
        string schoolname = cmbschoolname.Text;
        OleDbDataAdapter da = new OleDbDataAdapter("select  * from tblmedic where medicalschool ='"+combobox.text.ToString().Trim()+"'", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dataGridView1.DataSource = dt;
    }
