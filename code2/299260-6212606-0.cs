    public static MailAddressCollection ToAddressCollection(this IEnumerable<MailAddress> source)
    {
      var to = new MailAddressCollection();
      foreach(string r in source)
      {
        to.Add(new MailAddress(r));
      }
      return to;
    }
