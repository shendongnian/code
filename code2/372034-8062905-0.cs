    while (!success) {
        try
        {
           // Call a MS SQL stored procedure (MS SQL 2000)
           // Stored Procedure may deadlock 
           success = true;
        }
        catch
        {
           // if deadlocked Call a MS SQL stored procedure (may deadlock again)
           // If deadlocked, keep trying until stored procedure executes
           success = false;
        }
    }
