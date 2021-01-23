    public class NoDropDownBox : ComboBox
    {
        public override bool PreProcessMessage(ref Message msg)
        {
            int WM_SYSKEYDOWN = 0x104;
            bool handled = false;
            if (msg.Msg == WM_SYSKEYDOWN)
            {
                Keys keyCode = (Keys)msg.WParam & Keys.KeyCode;
                switch (keyCode)
                {
                    case Keys.Down:
                        handled = true;
                        break;
                }
            }
            if(false==handled)
                handled = base.PreProcessMessage(ref msg);
            return handled;
        }
        protected override void WndProc(ref Message m)
        {            
            switch(m.Msg)
            {
                case 0x201:
                case 0x203:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
