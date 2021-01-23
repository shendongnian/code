        MAPIUtilsClass util = null;
    
        try
        {
    
            util = new MAPIUtilsClass();
    
            MessageItem item = util.GetItemFromMsgFile(EmailPath, false);
    
            item.Import(EmailPath, 3);
    
            Subject = item.Subject;
    
            From = (item.SenderName.Length < 96) ? item.SenderName : item.SenderName.Substring(0, 93) + "...";
    
            To = (String.IsNullOrEmpty(item.To)) ? String.Empty : (item.To.Length < 96) ? item.To : item.To.Substring(0, 93) + "...";
    
            CC = (String.IsNullOrEmpty(item.CC)) ? String.Empty : (item.CC.Length < 96) ? item.CC : item.CC.Substring(0, 93) + "...";
    
            Sent = item.SentOn;
    
            Received = item.ReceivedTime;
    
            util.Cleanup();
    
            Log.Write("Redemption: Email data harvested: " + EmailPath);
    
    
        }
        catch (Exception exp)
        {
            Log.Write(String.Format("Error using Redemption API against: {0}\r\n{1}\r\n{2}",
                this.EmailPath, exp.Message, exp.StackTrace));
        }
    
        finally
        {
            if (util != null)
                util.Cleanup();
    
            GC.Collect();
        }
