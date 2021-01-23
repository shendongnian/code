        private int min = 1000;
        private int max = 0;
        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (min >= e.Index) min = e.Index+1;
            if (max <= e.Index) max = e.Index+1;
 
            float size = 10;
            System.Drawing.Font myFont;
            FontFamily family = FontFamily.GenericSansSerif; 
            System.Drawing.Color animalColor = System.Drawing.Color.Black;
            e.DrawBackground();
            Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2,
                    e.Bounds.Height, e.Bounds.Height - 4);
            e.Graphics.FillRectangle(new SolidBrush(animalColor), rectangle);
            myFont = new Font(family, size, FontStyle.Bold);
            e.Graphics.DrawString(comboBox3.Items[e.Index].ToString(), myFont, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
            label1.Text = String.Format("Values between {0} and {1}",min,max);
        }
