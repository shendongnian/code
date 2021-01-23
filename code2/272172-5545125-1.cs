            Bitmap bmp = new System.Drawing.Bitmap(200, 200);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                DrawText(true, gr, "TEST TEXT", new Font("Verdana", 20f, System.Drawing.FontStyle.Bold), Brushes.Red, StringFormat.GenericDefault, 100, 100, 45);
            }
