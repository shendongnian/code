    public class HTTransparentLabel : Label
    {
        private const int WM_NCHITTEST = 0x84; 
        private const int HTTRANSPARENT = -1; 
        protected override void WndProc(ref Message message) 
        { 
            if ( message.Msg == (int)WM_NCHITTEST ) 
                message.Result = (IntPtr)HTTRANSPARENT; 
            else 
                base.WndProc( ref message ); 
        }
    }
