    class MyTB : System.Windows.Forms.TextBox
    {
    
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
    
                case 0x302: //WM_PASTE
                    {
                        AddressTextBox.Text = Clipboard.GetText().Replace(Environment.NewLine, " ");
                        break;
                    }
    
            }
    
            base.WndProc(ref m);
        }
    
    }
