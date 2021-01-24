     Device.BeginInvokeOnMainThread(async () => {
    
                    try
                    {
                    using (this.Dialogs.Loading("Loading..."))
                    {
                            await Task.Delay(300);
                            //Your Service code
                    }
                  }
      catch (Exception ex)
            {
                    var val=ex.Message;
                UserDialogs.Instance.Alert("Test", val.ToString(), "Ok");
            }
        });
