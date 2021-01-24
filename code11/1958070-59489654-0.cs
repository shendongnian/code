    public class CloseButton : Button
    {
        GraphicsPath gPath;
        public CloseButton()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size = new System.Drawing.Size(50, 30);
            this.UseVisualStyleBackColor = true;
            gPath = new GraphicsPath();
            gPath.AddLine(20, 10, 30, 20);
            gPath.CloseFigure();
            gPath.AddLine(20, 20, 30, 10);
            gPath.CloseFigure();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            bool cursorInControl = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
            using (Pen gPen = new Pen(cursorInControl ? System.Drawing.SystemColors.ControlLightLight : System.Drawing.SystemColors.ControlText))
            {
                e.Graphics.DrawPath(gPen, gPath);
            }                
        }
    }
