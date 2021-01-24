    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    [DesignerCategory("Code")]
    class DateTimePickerYearMonth : DateTimePicker
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int DTM_FIRST = 0x1000;
        private const int DTM_GETMONTHCAL = DTM_FIRST + 8;
        private const int DTM_SETMCSTYLE = DTM_FIRST + 11;
        private const int DTM_GETMCSTYLE = DTM_FIRST + 12;
        private const int MCM_FIRST = 0x1000;
        private const int MCM_GETCURRENTVIEW = MCM_FIRST + 22;
        private const int MCM_SETCURRENTVIEW = MCM_FIRST + 32;
        private bool m_ShowToday = false;
        public enum MonCalView : int
        {
            MCMV_MONTH = 0,
            MCMV_YEAR = 1,
            MCMV_DECADE = 2,
            MCMV_CENTURY = 3
        }
        public enum MonCalStyles : int
        {
            MCS_DAYSTATE = 0x0001,
            MCS_MULTISELECT = 0x0002,
            MCS_WEEKNUMBERS = 0x0004,
            MCS_NOTODAYCIRCLE = 0x0008,
            MCS_NOTODAY = 0x0010,
            MCS_NOTRAILINGDATES = 0x0040,
            MCS_SHORTDAYSOFWEEK = 0x0080,
            MCS_NOSELCHANGEONNAV = 0x0100
        }
        public DateTimePickerYearMonth() {
            this.CustomFormat = "MM-yyyy";
            this.Format = DateTimePickerFormat.Custom;
            this.Value = DateTime.Now;
        }
        [
            Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue(false),
            Category("Appearance"), 
            Description("Shows or hides \"Today\" date at the bottom of the Calendar Control")
        ]
        public bool ShowToday {
            get => m_ShowToday;
            set {
                if (value != m_ShowToday) {
                    m_ShowToday = value;
                    ShowMonCalToday(m_ShowToday);
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ShowMonCalToday(m_ShowToday);
        }
        protected override void OnDropDown(EventArgs e)
        {
            var hWnd = SendMessage(this.Handle, DTM_GETMONTHCAL, 0, 0);
            if (hWnd != IntPtr.Zero) {
                SendMessage(hWnd, MCM_SETCURRENTVIEW, 0, (int)MonCalView.MCMV_YEAR);
            }
            base.OnDropDown(e);
        }
        private void ShowMonCalToday(bool show)
        {
            int styles = SendMessage(this.Handle, DTM_GETMCSTYLE, 0, 0).ToInt32();
            styles = show ? styles &~(int)MonCalStyles.MCS_NOTODAY : styles | (int)MonCalStyles.MCS_NOTODAY;
            SendMessage(this.Handle, DTM_SETMCSTYLE, 0, styles);
        }
            
    }
