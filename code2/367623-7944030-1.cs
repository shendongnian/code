        public void plotTheValues(List<Point> allValuesList)
        {
            foreach (Point val in allValuesList)
            {
                g.DrawString("X", new Font("Calibri", 12), new SolidBrush(Color.Black), x - val.X, y - val.Y);
            }
            
            display.Image = bmp;
        }
