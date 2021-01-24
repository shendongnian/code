          OracleDataReader dr;
          using (OracleConnection cn = new OracleConnection() { ConnectionString = "DATA SOURCE=*****:1521/ORCL;PASSWORD=*****;PERSIST SECURITY INFO=True;USER ID=*****" })
          {
            cn.Open();
            var sql =
              "Select B_NO,R_CLIENT_NAME,ENG_NAME,USER_NAME,R_ADDRESS,R_WORK_DATE,B_DATE,B_YEAR,B_WP_NAME,I_NAME,I_NO,BI_Q,I_CONTSR_TYPE_DESCR,R_PLACE_DESCR from VW_CI_REP_ITEMS_RESERV  where R_WORK_DATE = :fromDatePicker";
            OracleCommand cmd = new OracleCommand(sql, cn);
            var parameter = new OracleParameter("fromDatePicker", OracleDbType.Date) {
              Value = Convert.ToDateTime(from_datePicker.Text),
              
            };
            cmd.Parameters.Add(parameter);
            
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            da.Fill(ds2, "VW_CI_REP_ITEMS_RESERV");
            DeltaInvoices_Grid.ItemsSource = ds2.Tables["VW_CI_REP_ITEMS_RESERV"].DefaultView;
          }
          GridCount_txt.Text = DeltaInvoices_Grid.Items.Count.ToString();
