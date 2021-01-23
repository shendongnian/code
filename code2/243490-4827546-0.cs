     // Assuming all buttons subscribe to this event:
     private void buttons_MouseMove (object sender, MouseEventArgs e)
     {
       if (e.Button == System.Windows.Forms.MouseButtons.Left)
          {
           Control control = (Control) sender;
           if (control.Capture)
           {
              control.Capture = false;
           }
           if (control.ClientRectangle.Contains (e.Location)) 
           {
               Control.BackgroundImage = ...;
           }
        }
      }
