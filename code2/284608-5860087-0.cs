    class MyForm : Form
    {
        const int MyMessage = WM_USER + 0x05; // for example
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MyMessage)
            {
                // do whatever with your message
            }
        }
    }
