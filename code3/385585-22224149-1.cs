        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             // Set up string.
            string measureString = "HelloWorld";
            Font stringFont = new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel);
            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 10.0F, 10.0F, stringSize.Width, stringSize.Height);
            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(10, 10f + stringSize.Height / 12.0f));
        }
