    public DataTable GetData()
    {
        DataTable dt = new DataTable();
    
        string constr = ConfigurationManager.ConnectionStrings["OfficeConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT DisplayName 'Display Name', Replace(PrimaryEmailAddress,'SMTP:', ' ') 'Email Address', Replace(Licenses,'text:', ' ') 'License Type', LastPasswordChangeTimestamp 'Last Password Reset' FROM table"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (dt = new DataTable())
                    {
                        sda.Fill(dt);
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            
                            if (dt.Rows[i]["mycolumn"].ToString() == "")
                                dt.Rows[i].Delete();
                        }
                        //You have to specify All the column ....which you want to check  
    
                        dt.AcceptChanges();
    
                    }
                }
            }
        }
        return dt;
    }
