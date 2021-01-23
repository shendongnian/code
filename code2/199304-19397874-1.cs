     private void Registration_Load(object sender, EventArgs e)
        {
           
                            //hiding data grid view coloumn
                            datagridview1.AutoGenerateColumns = true;
                                datagridview1.DataSource =dataSet;
                                datagridview1.DataMember = "users"; //  users is table name
                                datagridview1.Columns[1].Visible = false;//hiding 1st coloumn coloumn
                                datagridview1.Columns[2].Visible = false; hiding 2nd coloumn
                                datagridview1.Columns[3].Visible = false; hiding 3rd coloumn
                            //end of hiding datagrid view coloumns
                
            }
            
        }
