     if (Dispatcher.CheckAccess())
     {
         control.Text = text;
     }
     else
     {
         SetTextCallback d = new SetTextCallback(SetText);
         Dispatcher.Invoke(d, new object[] { control, text });
     }
