            private void txtsearchgroup_KeyUp(object sender, KeyEventArgs e) {
            SqlConnection objconnection = new SqlConnection(servername and ...);
            DataView Dv = new DataView();
            objcommand = new SqlCommand("select name from groupitems", objconnection);
            objdataadapter = new SqlDataAdapter();
            objdataadapter.SelectCommand = new SqlCommand();
            objdataadapter.SelectCommand = objcommand;
            objdataset = new DataSet();
            objconnection.Open();
            objdataadapter.Fill(objdataset);
            Dv.Table = objdataset.Tables[0];
            Dv.RowFilter = " name LIKE '%" + txtsearchgroup.Text + "%'";
            dataGridView1.DataSource = Dv;
            objconnection.Close(); }
