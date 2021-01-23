     public void NotifyOnBarChange()
        {   
            if (NotifyBarChanged != null)
                     NotifyBarChanged(this,EventArgs.Empty);
        }
