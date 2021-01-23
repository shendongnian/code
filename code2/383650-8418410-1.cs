            foreach (var item in order.Items)
            {
               command.CommandText = "INSERT INTO OrderItem ... ";
               command.ExecuteNonQuery();
            }
    
            // Commit the transaction.
            sqlTran.Commit();
        }
        catch (Exception ex)
        {
            // Handle the exception if the transaction fails to commit.
            Console.WriteLine(ex.Message);
    
            try
            {
                // Attempt to roll back the transaction.
                sqlTran.Rollback();
            }
            catch (Exception exRollback)
            {
                // Throws an InvalidOperationException if the connection 
                // is closed or the transaction has already been rolled 
                // back on the server.
                Console.WriteLine(exRollback.Message);
            }
        }
    }
