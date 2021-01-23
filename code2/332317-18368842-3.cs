    try {
       System.Net.WebClient objClient = new System.Net.WebClient();
       string response;
       string title;
       string summary;
       //Creating a new xml document
       XmlDocument doc = new XmlDocument();
       //Logging in Gmail server to get data
       objClient.Credentials = new System.Net.NetworkCredential("Email", "Password");
       //reading data and converting to string
       response = Encoding.UTF8.GetString(
                  objClient.DownloadData(@"https://mail.google.com/mail/feed/atom"));
       response = response.Replace(
            @"<feed version=""0.3"" xmlns=""http://purl.org/atom/ns#"">", @"<feed>");
       //loading into an XML so we can get information easily
       doc.LoadXml(response);
       //nr of emails
       nr = doc.SelectSingleNode(@"/feed/fullcount").InnerText;
       //Reading the title and the summary for every email
       foreach (XmlNode node in doc.SelectNodes(@"/feed/entry")) {
          title = node.SelectSingleNode("title").InnerText;
          summary = node.SelectSingleNode("summary").InnerText;
       }
    } catch (Exception exe) {
       MessageBox.Show("Check your network connection");
    }
