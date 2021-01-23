        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(tabColorDictionary[tabControl2.TabPages[e.Index]]))
            {
                // Color the Tab Header
                e.Graphics.FillRectangle(br, e.Bounds);
                // swap our height and width dimensions
                var rotatedRectangle = new Rectangle(0, 0, e.Bounds.Height, e.Bounds.Width);
                
                // Rotate
                e.Graphics.ResetTransform();
                e.Graphics.RotateTransform(-90);
                // Translate to move the rectangle to the correct position.
                e.Graphics.TranslateTransform(e.Bounds.Left, e.Bounds.Bottom, System.Drawing.Drawing2D.MatrixOrder.Append);
                // Format String
                var drawFormat = new System.Drawing.StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                // Draw Header Text
                e.Graphics.DrawString(tabControl2.TabPages[e.Index].Text, e.Font, Brushes.Black, rotatedRectangle, drawFormat);
            }
        }
