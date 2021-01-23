    public class NoDropDownBox : ComboBox
    {
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
