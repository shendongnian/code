        void tekenScherm(object obj, PaintEventArgs pea)
        {
            float x, y, w, h, wOogLinks, wOogRechts;
            x = 100; y = 50; w = 300; h = 300;
            float scaleW = w / 300f;
            float scaleH = h / 300f;
            Pen pen = new Pen(Brushes.Black);
            pea.Graphics.FillEllipse(Brushes.Yellow, x, y, w, h);
            pea.Graphics.DrawEllipse(pen, x, y, w, h);
            pea.Graphics.FillEllipse(
                Brushes.White, 
                x + 50 * scaleW, 
                y + 50 * scaleH, 
                75 * scaleW, 
                75 * scaleH);
            pea.Graphics.FillEllipse(
                Brushes.White, 
                x + 170 * scaleW, 
                y + 50 * scaleH, 
                75 * scaleW, 
                75 * scaleH);
            pea.Graphics.DrawArc(
                pen, 
                x + 90 * scaleW, 
                y + 135 * scaleH, 
                125f * scaleW, 
                100f * scaleH, 
                0, 
                180);
        }
