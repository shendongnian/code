    MessageInterceptor pesanmasuk = new MessageInterceptor();
    pesanmasuk.EnableApplicationLauncher(applicationID);
    if (MessageInterceptor.IsApplicationLauncherEnabled(applicationID)) {
      string keyword;
      StreamReader key = new StreamReader(@"\Windows\conf.txt");
      string data = key.ReadToEnd();
      string[] isi = data.Split(new char[] { '\n' });
      keyword = isi[1];
      keyword = keyword.Replace(" ", "");
      pesanmasuk = new MessageInterceptor(InterceptionAction.NotifyAndDelete, false);
