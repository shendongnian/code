    userControl2.VisibleChanged += new EventHandler(this.UserControl2VisibleChanged);
    
    private void UserControl2VisibleChanged(object sender, EventArgs e)
    {
       if(userControl2.Visible)
       {
          CallMyMethodIWantToRunWhenUserControl2IsVisibleHere();
       }
    }
