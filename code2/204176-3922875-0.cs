    class MyServerParameters{
       string Server;
       string Username;
       string Password;
    }
    private void btnDownloadMails_Click(object sender, EventArgs e)      
    {      
        MyServerParameters p = new MyServerParameters();
        // we are still in UI thread so copy your values
        // to p
        p.Server = textServer.Text;         
        p.Username = textUser.Text;         
        p.Password = textPwd.Text;        
        Thread t = new Thread(new ParametricThreadStart(DownloadMailAsMsg));    
        // pass p to another thread  
        t.Start(p); // this will work...
      
    }  
    void DownloadMailAsMsg(object mp)   
    {
         // access p back like this...   
         MyServerParameters p = mp as MyServerParameters;
        dsserver.DocuShareAddress = p.Server;    
        dsserver.UserName = p.Username;    
        dsserver.Password = p.Password;   
       
