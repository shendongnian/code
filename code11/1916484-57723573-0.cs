     bool mIsPress = false;
     yourControl.KeyPress += new KeyPressEventHandler(keypressed);
     private void keypressed(Object o, KeyPressEventArgs e)
     {
        if (e.KeyChar == (char)Keys.W)
        {
             mIspress= true;
            e.Handled = true;
        }else{
             mIspress= false;
         }
     }
