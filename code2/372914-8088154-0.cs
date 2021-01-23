    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace FlashyButton
    {
        public partial class FlashyButton : UserControl
        {
            private CheckState _Checked = CheckState.Unchecked;
            [Browsable(true)]
            public override string Text
            {
                get
                {
                    return base.Text;
                }
                set
                {
                    base.Text = value;
                    lblText.Text = value;
                    Invalidate();
                }
            }
            public FlashyButton()
            {
                this.CausesValidation = true;
                InitializeComponent();
                lblText.MouseClick += (sender, e) => { OnMouseClick(null); };
            }
            public void SetFont(Font WhichFont)
            {
                this.Font = WhichFont;
            }
            public CheckState GetCheckedState()
            {
                return this._Checked;
            }
            public void SetCheckedState(CheckState NewCheckState) 
            {
                this._Checked = NewCheckState;
            }
            protected override void OnMouseClick(MouseEventArgs e)
            {
                this._Checked = (this._Checked == CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked;
                this.BorderStyle = (this._Checked == CheckState.Checked) ? System.Windows.Forms.BorderStyle.Fixed3D : System.Windows.Forms.BorderStyle.FixedSingle;
                tmrRedraw.Enabled = (this._Checked == CheckState.Checked);
                if (this._Checked == CheckState.Unchecked)
                {
                    this.BackColor = SystemColors.Control;
                }
                this.Invalidate();            //Force redraw
                base.OnMouseClick(e);
            }
            private float Percent = 100;
            private void tmrRedraw_Tick(object sender, EventArgs e)
            {
                Percent -= 2;
                if (Percent < -100) Percent = 100;
                this.BackColor = Color.FromArgb(
                    255, 
                    Lerp(255, SystemColors.Control.R, (int)Math.Abs(Percent)), 
                    Lerp(0, SystemColors.Control.G, (int)Math.Abs(Percent)), 
                    Lerp(0, SystemColors.Control.B, (int)Math.Abs(Percent))
                    );
            }
            private int Lerp(int Start, int End, int Percent)
            {
                return ((int) ((float)(End - Start) * ((float)Percent / 100f)) + Start);
            }
        }
    }
