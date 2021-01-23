            int magnificationIndex = 2;
            Bitmap tempRocket = new Bitmap("ccc.bmp");
            
            Bitmap tempBitmap = new Bitmap(97, 97);
            tempBitmap.SetResolution(tempRocket.HorizontalResolution * magnificationIndex,
                tempRocket.VerticalResolution * magnificationIndex);
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, 97, 97);
                g.DrawImage(tempRocket,0,0);
            }
            tempBitmap.Save("result.bmp");
