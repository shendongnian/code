    public void Method1(object someClassAsTSender, object parameter)
     {
       //i think parametertype = parameter...
       MessagingCenter.Subscribe<someClassAsTSender, object> (this, "messageKey", (message, args) =>
        {
           //convert the type (e.g  string data = args as string)
           Device.BeginInvokeOnMainThread(async () =>
            {
              //await do;
            });
        }
       );
     }
