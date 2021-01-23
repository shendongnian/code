    private _constring = new SqlConnection("Data Source=.\\SQLEXPRESS;"
            + "Initial Catalog=SIMON;"
            + "Persist Security Info=True;"
            + "User ID=username;Password=password");
    protected void btn_Add_Click(object sender, EventArgs e)
       {
    
            SqlTransaction trans = null;
            using (var con = new  SqlConnection(_constring))
            {
                con.Open();
                trans = con.BeginTransaction();
                using (
                   
                     string sqlStatement ="//SqlStuff";
                    var  sqlCmd = new  SqlCommand(sqlStatement,con))
                {
                     sqlCmd.Transaction = trans;
                     sqlCmd.Connection = con;
                    try
                    {
 
 
                        //sqlcmd.Parameters Stuff
                        sqlCmd.ExecuteNonQuery();
                        trans.Commit();
                       //SUCCESS
                    }
                   catch (Exception er)
                   {
                   error.InnerHtml = er.ToString();
                   return;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
