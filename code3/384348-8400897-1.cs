     private void NewDialog_KeyDown(object sender, KeyEventArgs e)
     {
            if(e.KeyData == Keys.A)
            {
                MethodToOutputSound(AEnum);
            }
            if(e.KeyData == Keys.B)
            {
                MethodToOutputSound(BEnum);
            }
            ...
     }
