    public class ComboBoxCustom : ComboBox {
        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateSolidBrush(int color);
        [DllImport("gdi32.dll")]
        internal static extern int SetBkColor(IntPtr hdc, int color);
        protected override void WndProc(ref Message m){
            base.WndProc(ref m);
            IntPtr brush;
            switch (m.Msg){
                case (int)312:
                    SetBkColor(m.WParam, ColorTranslator.ToWin32(this.BackColor));
                    brush = CreateSolidBrush(ColorTranslator.ToWin32(this.BackColor));
                    m.Result = brush;
                    break;
                default:
                    break;
            }
        }
    }
