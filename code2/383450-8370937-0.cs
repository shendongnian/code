    using(SqlConnection sc = new SqlConnection("Data Source=.\\SQLSERVER; Initial Catalog=BOSS; Integrated Security=TRUE"))
    using(SqlCommand cmdInsert = new SqlCommand("INSERT INTO dbo.Contact(FirstName, LastName) VALUES(@FIRSTNAME, @LASTNAME)", sc))
    {
       cmdInsert.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar, 100).Value = textBox2.Text;
       cmdInsert.Parameters.Add("@LASTNAME", SqlDbType.VarChar, 100).Value = textBox3.Text;
       sc.Open();
       cmdInsert.ExecuteNonQuery();
       sc.Close();
    }
