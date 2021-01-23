    finally
    {
         if(conn.ConnectionSTate=Connectionstate.open)
               {
                   conn.close()
               }
    }
