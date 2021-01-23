    private void Page_Load(object sender, System.EventArgs e)
    {
    	MailMessage mail = new MailMessage();
    	mail.To = "me@mycompany.com";
    	mail.From = "you@yourcompany.com";
    	mail.Subject = "this is a test email.";
    	string url = "http://www.microsoft.com";
    	mail.Body = HttpContent( url );
    	mail.BodyFormat = MailFormat.Html;
    	mail.UrlContentBase = url;
    	SmtpMail.SmtpServer = "localhost";  //your real server goes here
    	SmtpMail.Send( mail );
    }
    //screen scrape a page here
    private string HttpContent( string url )
    {
    	WebRequest objRequest= System.Net.HttpWebRequest.Create(url);
    	StreamReader sr =  new StreamReader( objRequest.GetResponse().GetResponseStream() );  
    	string result = sr.ReadToEnd();
    	sr.Close();
    	return result;
    }
