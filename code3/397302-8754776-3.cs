    private void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            System.Object lockThis = new System.Object();
    
            lock (lockThis)
            {
                bCheckVal = false;
    
                if (!this.bComplete)
                    stopOperation();
    
                Thread.Sleep(1000);
    
                Running  = false;
                bRefresh = false;
                this.bFlag = true;
            }
    
            this.Close();           
        }
        catch (System.Exception ex)
        {
        }
    }
