    cn.Open();
    cn.InfoMessage += delegate(object sender, SqlInfoMessageEventArgs e)
    {                                    
             txtMessages.Text += "\n" + e.Message;                                   
    };
