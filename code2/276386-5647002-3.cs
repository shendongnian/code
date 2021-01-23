     StringBuilder Content1 = new StringBuilder();
     Content1.Append("MailFrom:" + FromAdd + Constants.vbCrLf);
     Content1.Append("MailTo:" + EmailID + Constants.vbCrLf);
     Content1.Append("MailCC:" + MailCC + Constants.vbCrLf);
     Content1.Append("MailBCC:" + MailBCC + Constants.vbCrLf);
     Content1.Append("MailSubject:" + MailSubject + RequestNumber + Constants.vbCrLf);
     Content1.Append("MailAttachment:" + MailAttachment + Constants.vbCrLf);
     Content1.Append("MailBody:" + "" + Constants.vbCrLf);
     if (!File.Exists(Application.StartupPath)) {
	SW = File.CreateText(Application.StartupPath + "\\" + FinalPath);
	using (fs) {
	}
	Thread.Sleep(1000);
      }
      using (SW) {
	SW.Write(Content1.ToString);
     }
