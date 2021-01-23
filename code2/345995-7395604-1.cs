            void ClientAsyncOperationCompleted(object sender, AsyncOperationEventArgs e)
            {
                if (e.Error == null) {
                    //Normal execution path
                }
                else {
                    //you can put your structured exception handling code here around e.Error
                    if(e.Error is ConcreteException) {
                       //concrete exception handling
                    }
                    else {
                       //general exception handling
                    } 
                }
            }
