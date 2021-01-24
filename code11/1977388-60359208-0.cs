       protected override void OnPaint(PaintEventArgs args)
            {
                 args.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, this.Width, this.Height);
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(args.Graphics, Text, Font, new Point(Width + 3, this.Height / 2), ForeColor, flags);
                this.Image =Image.FromFile(@"C:\\Users\\Orbus\\Documents\\WorkSpace\VisualBasic6\\PCustomer\\Image\\Search.jpg");
                base.OnPaint(args);
            }
   
