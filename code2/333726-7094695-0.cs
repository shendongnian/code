    class DateTimePickerEX : DateTimePicker {
        const int WM_MOUSEDOWN = 0x201;
        int paddingright = 0;
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            int textwidth = 0;
            using (Graphics g = this.CreateGraphics()) {
                textwidth = (int)g.MeasureString(this.Text, this.Font).Width;
            }
            if (textwidth > this.Width - 35 - 22) {
                paddingright = 18;
            } else {
                paddingright = 35;
            }
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_MOUSEDOWN) {
                DWORD dw = new DWORD(m.LParam);
                int x = dw.HI;
                int y = dw.LO;
                if (x > this.Width - paddingright) {
                    OnButtonClick();
                    return;
                }
            }
            base.WndProc(ref m);
        }
        [EditorBrowsable( EditorBrowsableState.Never ), Browsable(false)]
        public new bool ShowUpDown {
            get;
            set;
        }
        private void OnButtonClick() {
            //-----------------------------------
            //####  Show your MonthCalendar  ####
            //-----------------------------------
        }
        [StructLayout(LayoutKind.Explicit)]
        struct DWORD {
            [FieldOffset(0)]
            public int Word;
            [FieldOffset(0)]
            public short HI;
            [FieldOffset(2)]
            public short LO;
            public DWORD(IntPtr word) {
                this.HI = 0;
                this.LO = 0;
                this.Word = (int)word;
            }
            public static DWORD Empty {
                get {
                    return new DWORD() {
                        Word = 0
                    };
                }
            }
        }
    }
