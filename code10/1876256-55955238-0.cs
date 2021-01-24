    string name = txtname.Text;
    string course = txtcourse.Text;
    string fee = txtfee.Text;
    string sql = "insert into record(name,course,fee) values(?,?,?)";
    using (var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=E:\school.accdb;")) {
        var cmd = new OleDbCommand(sql, con);
        cmd.Parameters.AddWithValue("name", name);
        cmd.Parameters.AddWithValue("course", course);
        cmd.Parameters.AddWithValue("fee", fee);
        con.Open();
        int n = cmd.ExecuteNonQuery();
        MessageBox.Show($"{n} Record adddedddd");
        txtname.Clear();
        txtcourse.Clear();
        txtfee.Clear();
        txtname.Focus();
    }
