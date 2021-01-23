    foreach (object obj in inboxFolder.Items)
    {
      MailItem mi = obj as MailItem;
      if (mi != null)
      {
        Console.WriteLine(mi.UserProperties.Item["test"].Value);
        Console.WriteLine(mi.ItemProperties.Item["test"].Value);
      }
    }
