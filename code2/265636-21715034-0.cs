    public static void DrawImageToGraphics(Graphics gr, Bitmap img, Rectangle DestRect, Color[] OldColors, Color[] NewColors, Color TransparantColor, uint Angle)
    {
        System.Drawing.Drawing2D.Matrix lmx = new System.Drawing.Drawing2D.Matrix();
        lmx.RotateAt(Angle, new PointF((DestRect.Left + DestRect.Right) / 2, (DestRect.Top + DestRect.Bottom) / 2));
        gr.Transform = lmx;
        System.Drawing.Imaging.ColorMap[] maps = new System.Drawing.Imaging.ColorMap[OldColors.Count() + 1];
        for (int i = 0; i < OldColors.Count(); i++)
        {
            maps[i].OldColor = OldColors[i];
            maps[i].NewColor = NewColors[i];
        }
        maps[OldColors.Count()].OldColor = TransparantColor;
        maps[OldColors.Count()].NewColor = Color.Transparent;
        System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes();
        attr.SetRemapTable(maps);
        gr.DrawImage(img, DestRect, 0, 0, img.Width, img.Height, GraphicsUnit.Point, attr);
    }
