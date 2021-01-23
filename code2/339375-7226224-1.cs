    const string SQL = "SELECT TOP 1 EventName FROM Event)";//the result of this statement to be stored in a string
    string resultFromSQL = "";
    using(SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PSeminar;Integrated Security=true;Trusted_Connection=Yes;MultipleActiveResultSets=true"))
    using(SqlCommand cmd = new SqlCommand(SQL, con))
    {
        con.Open();
        resultFromSQL = cmd.ExecuteScalar().ToString();
        con.Close();
    }
    foreach (ListItem li in ListBox1.Items)
    {
       // use string.Compare to be able to define whether or not you want to compare
       // in a case-sensitive way (or not) - here I picked not to check for case sensitivity
       if (string.Compare(li.Text, resultFromSQL, true) == 0)
       {
            Response.Redirect("asd.aspx?name=" + resultFromSQL);
       }
    }
