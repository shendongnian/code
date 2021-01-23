      public event EventHandler AllowDropChanged;
       
       private void OnAllowDropChanged()
       {
           if(AllowDropChanged!=null)
           {
               AllowDropChanged(this,new EventArgs());
           }
       }
