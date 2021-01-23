    item = (Microsoft.Office.Interop.Outlook.PostItem)inboxFolder.Items[i];
         Console.WriteLine("Item: {0}", i.ToString());
         Console.WriteLine("Subject: {0}", item.Subject);
         Console.WriteLine("Categories: {0}", item.Categories);
         Console.WriteLine("Body: {0}", item.Body);
          Console.WriteLine("HTMLBody: {0}", item.HTMLBody);
