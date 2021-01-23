    class MyComboBox: ComboBox
    {
        public MyComboBox()
        {
            this.SetStyle(ControlStyles.Opaque | ControlStyles.UserPaint, true);
            Items.Add("lol");
            Items.Add("lol2");  
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DroppedDown)
                ButtonRenderer.DrawButton(CreateGraphics(), new System.Drawing.Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 2, ClientRectangle.Height + 2), PushButtonState.Pressed);
            else
                ButtonRenderer.DrawButton(CreateGraphics(), new System.Drawing.Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 2, ClientRectangle.Height + 2), PushButtonState.Normal);
            if (SelectedIndex != -1)
            {
                Font font;
                if (SelectedItem.ToString().Equals("lol"))
                    font = new Font(this.Font, FontStyle.Bold);
                else
                    font = new Font(this.Font, FontStyle.Regular);
                e.Graphics.DrawString(Text, font, new SolidBrush(Color.Black), 3, 3);
            }
            if (DroppedDown)
                this.CreateGraphics().DrawImageUnscaled(new Bitmap("c:\\ArrowBlue.png"), ClientRectangle.Width - 13, ClientRectangle.Height - 12);
            else
                this.CreateGraphics().DrawImageUnscaled(new Bitmap("c:\\ArrowGray.png"), ClientRectangle.Width - 13, ClientRectangle.Height - 12);
            base.OnPaint(e);
        }
