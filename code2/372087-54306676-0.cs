    public class HintComboBox : ComboBox
    {
        string hint;
        public string Hint
        {
            get { return hint; }
            set { hint = value; Invalidate(); }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf && !Focused && string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Hint))
               using (var g = CreateGraphics())
               {
                   TextRenderer.DrawText(g, Hint, Font, ClientRectangle, SystemColors.GrayText, BackColor,
                                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
               }
        }
    }
