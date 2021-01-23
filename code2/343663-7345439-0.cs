    //Receive mail
    Pop3Client cl = new Pop3Client();
    cl.ServerName = "your server name";
    cl.UserName = "your name";
    cl.Password = "pass";
    cl.Ssl = false;
    if (cl.Authenticate() == true)
    {
        Int32 MailIndex = 1;
        Pop3Message mg = cl.GetMessage(MailIndex);
        String mailTo = mg.To;
        String mailCc = mg.Cc;
        String title = mg.Subject;
        String bodyText = mg.BodyText;
        //Save Image to your local hard disk
        foreach(Pop3Content ct in mg.Contents)
        {
            String filePath = "C:\MyFolder\" + ct.ContentDisposition.FileName;
            ct.DecodeData(filePath);
        }
    }
