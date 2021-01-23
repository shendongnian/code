    public int SaveMail(ImapX.Message mess)
    {
         if(this.InvokeRequired)
         {
                return (int) this.Invoke(
                       new Func<ImapX.Message, int>( m => SaveMail(mess)) );
         }
         else
         {
            if (!File.Exists(@"D:\" + Username + "\\" + MailTree.SelectedNode.Text + "\\" + mes.MessageUid.ToString() + ".eml"))
            {
                mess.Process();
                mess.SaveAsEmlToFile(@"D:\" + Username + "\\" + MailTree.SelectedNode.Text + "\\", mes.MessageUid.ToString());   //Store messages to a Location 
    
            }
           // mes.MessageUid=mess.MessageUid;
            return 1;  
     
         }
          
    }
