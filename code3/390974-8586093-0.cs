    //get max count of orders on server .2
    public int getmaxcountfornos(string caseno,TextBox TextBox3)
    {
        int count2 = 0;
        try
        {
            String dd_webCofig = ConfigurationManager.ConnectionStrings["counton140"].ConnectionString;
            OdbcConnection ddlistconn = new OdbcConnection(dd_webCofig);
            ddlistconn.Open();
            string cnt_2 = "select count(nos) from training_jud.orders where fil_no=@b and jdate=@c";
            OdbcCommand ddlistCmd_2 = new OdbcCommand(cnt_2, ddlistconn);
            ddlistCmd_2.Parameters.AddWithValue("**@b**", caseno);
            ddlistCmd_2.Parameters.AddWithValue("**@c**", Convert.ToDateTime(TextBox3.Text).ToString("yyyy-MM-dd"));
            count2 = **Convert.ToInt32**(ddlistCmd_2.ExecuteScalar());
        }
        catch (Exception ee)
        {
            HttpContext.Current.Response.Write(ee.Message);
        }
        return count2;
    }
