     public class LockedForm : Form
     {
            protected override void WndProc(ref Message message)
            {
                int WM_NCLBUTTONDOWN = 0xA1;
                int WM_SYSCOMMAND = 0x112;
                int HTCAPTION = 0x02;
                int SC_MOVE = 0xF010;
    
                if (message.Msg == WM_SYSCOMMAND && message.WParam.ToInt32() == SC_MOVE)
                {
                    return;
                }
    
                if (message.Msg == WM_NCLBUTTONDOWN && message.WParam.ToInt32() == HTCAPTION)
                {
                    return;
                }
    
                base.WndProc(ref message);
            }
     }
