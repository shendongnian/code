    using(var conection = new SqlConnection(""))
    { 
       connection.Open();
       using(var cmd = new SqlCommand("UPDATE QUERY", connection))
       {
         cmd.ExecuteNonQuery();    // Or better use Async version with await
       }
    }
