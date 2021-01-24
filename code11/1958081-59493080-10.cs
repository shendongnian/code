    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class MyCloseButton : Button
    {
        public MyCloseButton()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.IndianRed;
            FlatAppearance.MouseOverBackColor = Color.DarkRed;
            FlatStyle = FlatStyle.Flat;
            Font = new Font(Font.FontFamily, 13);
            Size = new Size(56, 36);
            UseVisualStyleBackColor = false;
            MouseLeave += (s, e) => ForeColor = Color.Black;
            MouseEnter += (s, e) => ForeColor = Color.White;
        }
        public override string Text { get => ""; set => base.Text = ""; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            TextRenderer.DrawText(e.Graphics, "✕", Font, ClientRectangle, ForeColor);
        }
    }
