    Timer timer = new Timer();
    timer.Interval = 500;
    timer.Enabled = false;
    
    timer.Start();
    
    if( messagesNum > oldMessagesNum)
      timer.Tick += new EventHandler( timer_Tick );
    else
      timer.Tick -= timer_Tick;
    void timer_Tick( object sender, EventArgs e )
    {
       if(messageLabel.BackColor == Color.Black)
          messageLabel.BackColor = Color.Red;
       else
          messageLabel.BackColor = Color.Black;
    }
