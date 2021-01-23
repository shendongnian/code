    const string SQL = "SELECT EventName FROM Event";   //the result of this statement to be stored in a string
    List<string> eventNames = new List<string>();
    // set up SQL connection and command
    using(SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=PSeminar;Integrated Security=true;Trusted_Connection=Yes;MultipleActiveResultSets=true"))
    using(SqlCommand cmd = new SqlCommand(SQL, con))
    {
        con.Open();
         
        // get a SqlDataReader to read multiple rows
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
           // while there are more result rows.....
           while(rdr.Read())
           {
               // grab the 0-index value from the result row
               eventNames.Add(rdr.GetString(0));
           }
        }
         
        con.Close();
    }
    foreach (ListItem li in ListBox1.Items)
    {
       // for each of the selected items in the ListBox - check if their .Text
       // is contained in the list of event names retrieved from the database table
       if (li.Selected && eventNames.Contains(li.Text))
       {
            Response.Redirect("asd.aspx?name=" + resultFromSQL);
       }
    }
