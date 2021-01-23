    Guid newGuid = Guid.NewGuid();
    Guid retrieved = Guid.Empty;
        using (FbConnection conn = new FbConnection(connectionString)) {
            conn.Open();
        
            using (FbCommand cmd = conn.CreateCommand()) {
            // first create the table for testing
            cmd.CommandText = "recreate table GUID_test (guid char(16) character set octets)";
            cmd.ExecuteNonQuery();
        }
        
        using (FbCommand cmd = conn.CreateCommand()) {
            // inserting GUID into db table  
            cmd.CommandText = "insert into GUID_test values (@guid)";
        
            // classic way, works good
            //cmd.Parameters.Add("@guid", FbDbType.Char, 16).Value = newGuid.ToByteArray();
                            
            // another way, maybe better readability, but same result
            cmd.Parameters.Add("@guid", FbDbType.Guid).Value = newGuid;
        
            cmd.ExecuteNonQuery();
        }
        
        using (FbCommand cmd = conn.CreateCommand()) {
            // reading GUID back from db  
            cmd.CommandText = "select first 1 guid from GUID_test";
        
            retrieved = (Guid)cmd.ExecuteScalar();
        }
        
                        
        using (FbCommand cmd = conn.CreateCommand()) {
            // drop the table, it has no real application
            cmd.CommandText = "drop table GUID_test";
            cmd.ExecuteNonQuery();
        }
    }
    MessageBox.Show(newGuid.Equals(retrieved).ToString());
