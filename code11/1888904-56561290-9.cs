     try
                {
                  
                    PhoneDialer.Open(number);           
                    MessagingCenter.Subscribe<Object>(this, "CallConnected", (sender) => {
                         CallStartTime = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss"));
                    });
                    MessagingCenter.Subscribe<Object>(this, "CallEnded", (sender) => {
                    CallEndTime = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss"));
                    CallDuration = CallEndTime - CallStartTime;
                    });
    
                              
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Phone Dialer is not supported on this device.  
                }
