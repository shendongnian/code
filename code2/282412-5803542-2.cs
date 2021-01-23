     if (control.Dispatcher.CheckAccess())
     {
         control.Text = text;
     }
     else
     {
         SetTextCallback d = new SetTextCallback(SetText);
         control.Dispatcher.Invoke(d, new object[] { control, text });
     }
