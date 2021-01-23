    class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);
       
        private uint _messageId = RegisterWindowMessage("MyUniqueMessageIdentifier");
        
        protected override void WndProc(ref Message m)
        {
           if (m.Msg == _messageId)
           {
               // do stuff
                        
           }
           base.WndProc(ref m);
        }
    }
