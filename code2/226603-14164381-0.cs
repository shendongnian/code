            try
            {
                string sSql;
                if (Register)
                   sSql = "call dbms_alert.register('XYZ')";
                else
                   sSql = "call dbms_alert.remove('XYZ')";
                dbmsAlert = new OracleCommand();
                dbmsAlert.CommandText = sSql;
                dbmsAlert.ExecuteNonQuery();  
                if (Register) //start the background thread
               {
                   DBMSAlertThread = new Thread(AlertEvent);
                   DBMSAlertThread.IsBackground = true;
                   DBMSAlertThread.Start();
               }
            }
            catch (Exception LclExp)
            {
                //Show error or capture in eventlog
            }            
        }
