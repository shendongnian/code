    protected void OnOkHandler(object sender, EventArgs e)
          {
              MessageBox.Show("Hello: " +_WPFUserControl.UserName + " you clicked Ok Button");
          }
 
   
       protected void OnCancelHandler(object sender, EventArgs e)
          {
                MessageBox.Show("you clicked Cancel Button");
          }
