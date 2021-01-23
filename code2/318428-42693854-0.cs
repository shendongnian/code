     String constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+txtSourceFile.Text+";Extended Properties='Excel 8.0;HDR=YES;';";
            String constr2 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtLibrary.Text + ";Extended Properties='Excel 8.0;HDR=YES;';";
            OleDbConnection con = new OleDbConnection(constr);
            OleDbConnection con2 = new OleDbConnection(constr2);
            OleDbConnection con3 = new OleDbConnection(constr);
            
            OleDbCommand oconn = new OleDbCommand("Select * From [eudra$]", con);
            OleDbCommand oconn2 = new OleDbCommand("Select * From [Sheet1$]", con2);
            OleDbCommand oconn3 = new OleDbCommand("Select * From [eudra$] where EXAMPARM in ('with one or more serious adverse events','with one or more non-serious adverse events that met the incidence cutoff')", con);
            
            if (txtSourceFile.Text != "")
            {
                con.Open();
                con2.Open();
                con3.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                OleDbDataAdapter sda2 = new OleDbDataAdapter(oconn2);
                OleDbDataAdapter sda3 = new OleDbDataAdapter(oconn3);
                DataTable data = new DataTable();
                sda.Fill(data);
                DataTable data2 = new DataTable();
                sda2.Fill(data2);
                DataTable data3 = new DataTable();
                sda3.Fill(data3);
                
                var test = JoinDataTables(data, data2, (row1, row2) => (row1.Field<string>("BODY_SYS").ToUpper() == row2.Field<string>("Term").ToUpper() ));
                data3.Merge(test, true);
                dgvImp.DataSource = data3;
                con.Close();
            }
