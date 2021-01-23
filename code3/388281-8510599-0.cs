            DbTransaction tx = null;
            try
            {
                tx = Connection.CreateTransaction();
                Connection.ExecuteNonQuery(tx, "SPNameOrSQLInstruction", new object[] { param1, param2 });
                tx.Commit();
            }
            catch (Exception ex)
            {
                if(tx != null)
                    tx.Rollback();
                Logger.Log (ex);
            }
