    class Form1
    {
     ...
     
     // You need to have the msgSet available for your event, so it should be 
     // a field (or property) on the form:
     Chilkat.EmailBundle bundle;
     
     // Call this e.g. on start up and possibly when a
     // refresh button is clicked:
     protected void RefreshMailBox()
     {
      Chilkat.Imap imap = new Chilkat.Imap();
      imap.UnlockComponent("");
      imap.Port = 993;
      imap.Ssl = true;
      imap.Connect("imap.gmail.com");
      imap.Login("user@email.com", "pass");
      imap.SelectMailbox("Inbox");
    
      Chilkat.MessageSet msgSet = imap.Search("ALL", true); 
      bundle = imap.FetchBundle(msgSet);
     }
     
     protected void YourEventHandler()
     {
      if (listView1.SelectedItems.Count > 0)
      {
       // bundle is now accessible in your event handler:
       richTextBox1.Text = bundle.GetEmail((int)listView1.SelectedItems[0].Tag).Body;
      }
     }
    
     ...
    }
