            float fontSize = 25f;
            float rotation = 30f;
            RectangleF txBounds = GetRotatedTextBounds("TEST TEXT", new Font("Verdana", fontSize, System.Drawing.FontStyle.Bold), StringFormat.GenericDefault, rotation, 96f);
            float inflateValue = 10 * (fontSize / 100f);
            txBounds.Inflate(inflateValue, inflateValue);
            Bitmap bmp = new System.Drawing.Bitmap((int)txBounds.Width, (int)txBounds.Height);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.Clear(Color.White);
                DrawText(true, gr, "TEST TEXT", new Font("Verdana", fontSize, System.Drawing.FontStyle.Bold), Brushes.Red, new StringFormat(System.Drawing.StringFormatFlags.DisplayFormatControl), 0, 0, txBounds.Width, txBounds.Height, rotation);
            }
