        public class tb : TextBox
                {
            
                    private const int  WM_MOUSELEAVE = 0x02A3;
            
                    protected override void WndProc(ref Message m)
                    {
                        if (m.Msg == WM_MOUSELEAVE)
                        {
                            // not passing the message on, so does nothing.
                            // handle it yourself here or leave empty.
                        }
                        else
                        {
                            // otherwise let windows handle the message
                            base.WndProc(ref m);
                        }
                    }
                }
