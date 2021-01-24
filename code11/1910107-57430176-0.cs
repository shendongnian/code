    //DONE: we should check for null
    //DONE: it's Yahoo if it ends on @yahoo.com (not contains)
    public static bool IsYahoo(TextBox sender) =>
      sender != null && 
      sender.Text.TrimEnd().EndsWith("@yahoo.com", StringComparison.OrdinalIgnoreCase);
    public static bool IsGmail(TextBox sender) =>
      sender != null && 
      sender.Text.TrimEnd().EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
    public static void InsertYahoo(TextBox sender) {
      if (null == sender)
        throw new ArgumentNullException(nameof(sender));
      if (IsYahoo(sender))
        return;
      // Uncomment, In case you want to change gmail only
      //if (!IsGmail(sender)) 
      //  return;
      // If we have an eMail like bla-bla-bla@somewhere
      int p = sender.Text.LastIndexOf('@');
   
      // ... we change somewhere to yahoo.com
      if (p > 0)
        sender.Text = sender.Text.Substring(0, p) + "@yahoo.com";
    } 
