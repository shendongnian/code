            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            using (var cmd = new SqlCommand(@"
                    INSERT INTO MagicBoxes (OwnerID, [Key], Name, [Permissions], Active, LastUpdated) 
                    OUTPUT INSERTED.Id
                    VALUES (@OwnerID, @BoxKey, @BoxName, 0, 1, @Date) ", conn))
            {
                cmd.Parameters.AddRange(new[]
                    {
                        new SqlParameter("@OwnerID", SqlDbType.Int).Value = OwnerID,
                        new SqlParameter("@BoxKey", SqlDbType.VarChar).Value = BoxKey, 
                        new SqlParameter("@BoxName", SqlDbType.VarChar).Value = BoxName, 
                        new SqlParameter("@Date", SqlDbType.DateTime).Value = DateTime.Now 
                    });
                
                conn.Open();
                var id = (int)cmd.ExecuteScalar();
            }
