    public void DrawText()
        {
            device.DrawString(textChar[num].ToString(), font, Brushes.Red, 10, 10 + num * 22)
            num++;
            pb.Image = surface;
        }
