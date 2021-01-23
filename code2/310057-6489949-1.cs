    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace MyControls
    {
        public class HintedTextBox : TextBox
        {
            public HintedTextBox() : base() { ResetHintColor(); }
    
            [Description("The color of the hint text to display"),
            Category("Appearance")]
            public Color HintColor { get; set; }
            // Default value handling for HintColor
            private Color DefaultHintColor { get { return Color.LightGray; } }
            public void ResetHintColor() { HintColor = Color.LightGray; }
            public bool ShouldSerializeHintColor() { return !HintColor.Equals(DefaultHintColor); }
    
            [Description("The textual hint to display in the textbox"),
            Category("Behavior"),
            Localizable(true)]
            public string HintText
            {
                get { return m_hintText; }
                set
                {
                    if (m_hintText != value)
                    {
                        m_hintText = value;
                        UpdateHintTextState(true);
                    }
                }
            }
            private string m_hintText = "";
    
            protected override void OnGotFocus(EventArgs e)
            {
                base.OnGotFocus(e);
                HasFocus = true;
                UpdateHintTextState();
            }
    
            protected override void OnLostFocus(EventArgs e)
            {
                base.OnLostFocus(e);
                HasFocus = false;
                UpdateHintTextState();
            }
    
            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                UpdateHintTextState();
            }
    
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 15) // WM_PAINT
                {
                    PaintHintText();
                }
            }
    
            private bool DisplayHintText { get; set; }
    
            private bool HasFocus { get; set; }
    
            private void PaintHintText()
            {
                if (DisplayHintText)
                {
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    using (SolidBrush b = new SolidBrush(HintColor))
                    {
                        StringFormat sf = new StringFormat();
                        switch (this.TextAlign)
                        {
                            case HorizontalAlignment.Center:
                                sf.Alignment = StringAlignment.Center;
                                break;
                            case HorizontalAlignment.Right:
                                sf.Alignment = StringAlignment.Far;
                                break;
                            default:
                                sf.Alignment = StringAlignment.Near;
                                break;
                        }
                        g.DrawString(HintText, Font, b, ClientRectangle, sf);
                    }
                }
            }
            
            private void UpdateHintTextState() { UpdateHintTextState(false); }
            private void UpdateHintTextState(bool forceInvalidate)
            {
                bool prevState = DisplayHintText;
    
                if (HintText.Length == 0)
                    DisplayHintText = false;
                else if (Text.Length != 0)
                    DisplayHintText = false;
                else
                    DisplayHintText = !HasFocus;
    
                if (DisplayHintText != prevState || forceInvalidate)
                    Invalidate();
            }
        }
    }
