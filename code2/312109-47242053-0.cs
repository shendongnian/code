        public bool IsConnected()
        {
            if (db == null) //db here is an Entity
                return false;
            //in my case Connection is an sqlconnection object so you can 
            //apply the same to your connection
            if (db.Database.Connection.State == ConnectionState.Closed)
                return false;
            try
            {
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "SELECT 0";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }
