                string sp = "Entities.StoredProcedureName";
                var conn = (EntityConnection)dbContext.Connection;
                conn.Open();
                EntityCommand cmd = new EntityCommand(sp, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Parameter1", [type]).Value = paramvalue;
                cmd.ExecuteNonQuery();
