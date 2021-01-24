    private delegate void dlgUpdateRows(object[] rx_can_msg, int tID);
    // Write actual type of rx_can_msg instead of object[] in method signature , second parameter should be your thread id if needed
    private void UpdateRows(object[] rx_can_msg, int tID =0)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    object[] obj = new object[2];
                    obj[0] = rx_can_msg;
                    obj[1] = Thread.CurrentThread.ManagedThreadId;
                    this.Invoke(new dlgUpdateRows(UpdateRows), obj);
                }
                else
                {
                    //Here update your datagrid using rx_can_msg
                }
                //This row is important to avoid blocking
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                //Do error handling
            }
        }
