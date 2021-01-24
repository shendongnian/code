     Task.Factory.StartNew(
                            () =>
                                WriteMessageInBackground(invoicesIn.Split(','),  _messageController, chkSms.Checked,
                                    chkEmail.Checked, messageTemplate),
                            CancellationToken.None,
                            TaskCreationOptions.PreferFairness,
                            TaskScheduler.Default);
    
             
