    class Class1
    {
         string str = "* FLAGS (\\Answered \\Flagged \\Draft \\Deleted \\Seen)\r\n* OK [PERMANENTFLAGS ()] Flags permitted.\r\n* OK [UIDVALIDITY 657136382] UIDs valid.\r\n* 3 EXISTS\r\n* 0 RECENT\r\n* OK [UIDNEXT 4] Predicted next UID.\r\n. OK [READ-ONLY] INBOX selected. (Success)\r\n";
                  
         public void FindString(string parm)
         {
             if (str.Contains(parm))
             {
                 string[] parts = str.Split('*');
                 foreach (var item in parts)
                 {
                     if (item.Contains(parm))
                     {
                         string[] values = item.Split(' ');
                         string value = values[1];
                     }
                 }
             }
         }
    
         static void Main(string[] args)
         {
             Class1 c = new Class1();
             c.FindString("EXISTS");
         }
    }
