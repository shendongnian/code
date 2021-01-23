    public int WrapInsert(Parameters)
            {
                .....
                int RowsAffected = this.Insert(..Parameters..);
                if ( RowsAffected > 0)
                {
                    try
                    {
                        SqlCommand cm = this.Connection.CreateCommand();
                        cm.CommandText = "SELECT @@IDENTITY";
                        identity = Convert.ToInt32(cm.ExecuteScalar());
                    }
                    finally
                    {
                        ....
                    }
                }
    
                return RowsAffected;
            }
