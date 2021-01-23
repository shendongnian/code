       Add Delay some miliSec. Delay then call Focus() and Not forget to put 
       inside Dispatcher.
     
       Task.Delay(100).ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    TextBoxNAme.Focus();
                }));
            });
