    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            {
                switch ((HitTestValues)m.Result)
                {
                    case HitTestValues.HTBORDER:
                    case HitTestValues.HTBOTTOM:
                    case HitTestValues.HTBOTTOMLEFT:
                    case HitTestValues.HTBOTTOMRIGHT:
                    case HitTestValues.HTCAPTION: 
                    case HitTestValues.HTGROWBOX:
                    case HitTestValues.HTLEFT:
                    case HitTestValues.HTRIGHT:
                    case HitTestValues.HTTOP:
                    case HitTestValues.HTTOPLEFT:
                    case HitTestValues.HTTOPRIGHT:
                        m.Result = (IntPtr)HitTestValues.HTNOWHERE;
                        break;
                }
            }
        }
        private const int WM_NCHITTEST = 0x84;
        enum HitTestValues
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21
        }
    }
