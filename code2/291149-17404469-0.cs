        string DB = Server.MapPath("App_Data/OnlineTestEngine.mdb");
        con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + DB);
        
        string query = "Select * from current_test";
        con.Open();
        cmd1 = new OleDbCommand(query, con);
        try
        {
            dr = cmd1.ExecuteReader();
            if (dr.GetName(0).ToString() == "Qno")
            {
                Label1.Text = "Table Already Exist";
                dr.Close();
                con.Close();
                con.Open();
                string q = "Drop table current_test";
                OleDbCommand cmd2 = new OleDbCommand(q, con);
                cmd2.ExecuteNonQuery();
                Label1.Text += " | Table Deleted from Database";
            }
        }
        catch(Exception ex)
        {
            Label1.Text = "Table Not Exist";
            string query2 = "create table current_test(Qno counter, Questions varchar(255), ans1 varchar(255), ans2 varchar(255), ans3 varchar(255), ans4 varchar(255), right_ans varchar(255), marks int, response int, PRIMARY KEY (Qno))";
            cmd3 = new OleDbCommand(query2, con);
            con.Close();
            con.Open();
            dr = cmd3.ExecuteReader();
            Label1.Text += " | Table Created Sucessfully";
            
        }
        finally
        {
            con.Close();
        }
    }
