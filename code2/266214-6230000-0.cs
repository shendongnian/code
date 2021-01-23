            private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            var arial_8 = new Font("Arial", 8);
            var webdings_10 = new Font("Webdings", 10);
            var richTexts = new RichText[] {
            new RichText("Default text and this is the lengthy string to check the display. One more line to verify again")
            , new RichText("Default green text. this is the lengthy string to check the display. One more line to verify again", Color.Green)
            , new RichText("Regular arial 8.", arial_8)
            , new RichText("Bold arial 8.", new Font(arial_8, FontStyle.Bold))
            };
            var g = e.Graphics;
            Point textPosition = new Point(0, 0);
            int maxWidth = this.pictureBox2.ClientSize.Width;
            foreach (var richText in richTexts)
            {
                var text = richText.Text;
                if (string.IsNullOrEmpty(text)) { continue; }
                var font = richText.Font ?? Control.DefaultFont;
                var textColor = richText.TextColor ?? Control.DefaultForeColor;
                using (var brush = new SolidBrush(textColor))
                {
                    string[] strs = text.Split(new string[] { " " }, StringSplitOptions.None);
                    int fontheight = (int)g.MeasureString("\r\n", font).Height;
                    foreach (string val in strs)
                    {
                        var measure = g.MeasureString(val, font);
                        if (measure.Width + textPosition.X > maxWidth)
                        {
                            var newPosition = textPosition;
                            newPosition.X = 0;
                            newPosition.Y = textPosition.Y + fontheight;
                            textPosition = newPosition;
                        }
                        g.DrawString(val, font, brush, textPosition);
                        var nextposition = textPosition;
                        nextposition.X = textPosition.X + (int)measure.Width;
                        textPosition = nextposition;
                    }
                }
            }
        }
