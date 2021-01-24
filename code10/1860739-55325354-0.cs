            SqlConnection cnRemoteBye = new SqlConnection();
            SqlCommand cmdRemoteBye = new SqlCommand();
            cnRemoteBye.ConnectionString = @"Data Source=(LocalDB)\v11.0;Integrated Security=True";
            cmdRemoteBye.CommandText = "ALTER DATABASE [JVT-Inventory] SET OFFLINE WITH ROLLBACK IMMEDIATE \n\r exec sp_detach_db @dbname = [JVT-Inventory]";
            cmdRemoteBye.Connection = cnRemoteBye;
            cnRemoteBye.Open();
            cmdRemoteBye.ExecuteNonQuery();
            cnRemoteBye.Close();
``
