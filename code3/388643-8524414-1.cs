    static void Main2(string[] args) {
      const string stackOverflowUrl = @"http://stackoverflow.com/questions/8520488/some-delay-processing-message-in-messageinterceptor";
      string empty = String.Empty;
      StreamReader key = new StreamReader(@"\Windows\conf.txt");
      string data = key.ReadToEnd();
      string[] lines = data.Split(new char[] { '\n' });
      string keyword = lines[1].Replace(" ", empty);
      string applicationID = "trackingApplication";
      using (MessageInterceptor smsInterceptor = new MessageInterceptor(applicationID, false)) {
        smsInterceptor.InterceptionAction = InterceptionAction.NotifyAndDelete;
        smsInterceptor.MessageCondition = new MessageCondition(MessageProperty.Body, MessagePropertyComparisonType.StartsWith, empty + keyword);
        smsInterceptor.MessageReceived += new MessageInterceptorEventHandler(Intercept_MessageReceived);
        smsInterceptor.EnableApplicationLauncher(applicationID);
        if (MessageInterceptor.IsApplicationLauncherEnabled(applicationID)) {
          // Here, you'd need to launch your Form1 or enable some timer,
          // otherwise the code will return immediately and the MessageInterceptor
          // instance will be disposed of.
        }
        smsInterceptor.MessageReceived -= MessageInterceptorEventHandler;
      }
    }
    static void Intercept_MessageReceived(object sender, MessageInterceptorEventArgs e) {
      SmsMessage newMessage = e.Message as SmsMessage;
      if (newMessage != null) {
        Console.WriteLine("From: {0}", newMessage.From.Address);
        Console.WriteLine("Body: {0}", newMessage.Body);
        string[] command = newMessage.Body.Split(new char[] { '.' });
        string line = command[1];
        if (line == "helo") {
          /*do some Stuff*/
        }
      }
    }
