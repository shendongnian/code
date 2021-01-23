    public class NoDropDownBox : ComboBox
    {
        protected override void WndProc(ref Message m)
        {
            System.Diagnostics.Debug.WriteLine(m.Msg);
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
