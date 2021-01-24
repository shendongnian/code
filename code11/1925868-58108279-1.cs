    protected void editDeliveredDate_DateChanged(object sender, EventArgs e)
    {
        ASPxDateEdit dateEdit = sender as ASPxDateEdit;
        // I made your currentDate variable to be nullable
        DateTime? currentDate = dateEdit.Date; 
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ACAOSBConnectionString"].ToString()))
        {
            string ordstr = (txt_orderid.Text != null) ? txt_orderid.Text : string.Empty;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "usp_load_status_update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ordstr.ToString();
            cmd.Parameters.Add("@loginname", SqlDbType.VarChar, 512).Value = Page.User.Identity.Name;
            if(currentDate != null)
            { 
                // only set the parameter if it's not null, this will allow the SQL sproc to use its existing logic	       
                cmd.Parameters.Add("@datecompleted", SqlDbType.DateTime).Value = currentDate;
            }
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //TODO: save log for now;
                int ex_errorid = 0;
                string ex_msg = string.Concat((ex != null && ex.Message != null) ? ex.Message.ToString() : (ex != null && ex.InnerException != null) ? ex.InnerException.ToString() : "No Message Found ", (ex != null && ex.StackTrace != null) ? ex.StackTrace.ToString() : "No Strack Trace ");
                int ex_genericid = 0;
                string ex_username = (Page != null && Page.User != null && Page.User.Identity != null && Page.User.Identity.Name != null) ? Page.User.Identity.Name : "No user found";
                Jobs.log_somewhere ex_errorlog = new Jobs.log_somewhere();
                ex_errorlog.log_secos_error(ex_errorid, ex_msg, ex_genericid, ex_username);
            }
        }
    }
