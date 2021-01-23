    public void AddAttachment(string attachment) //well I know it looks strange
    {
       byte[] bytes = null;
       try
       {
           bytes = Convert.FromBase64String(attachment);
       }
       catch
       {
           //invalid string format
       }
    }
