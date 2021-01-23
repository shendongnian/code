    private void printBitmap(rows, columns, numOfWhites, numOfblack /*, numOf... */) {
        Bitmap bmp = new Bitmap(rows * 10, columns * 10);
        Graphics g = Graphics.FromImage(bmp);
        SolidBrush bWhite = new SolidBrush(Color.White);
        SolidBrush bBlack = new SolidBrush(Color.Black);
        // ...SolidBrush bColor = new SolidBrush(Color.AnyColor);
        // ...
        int countNumOfWhites = 0;
        int countNumOfBlacks = 0;
        // int countNumOf... = 0;
        // ...
        for(int c = 0; c < columns; c++)
        {
            for(int r = 0; r < rows; r++)
            {
                if(countNumOfWhites < numOfWhites)
                {
                    g.FillRectangle(bWhite, new Rectangle(r * 10, c * 10, (r + 1) * 10, (c + 1) * 10);
                    countNumOfWhites++; 
                }
                else if(countNumOfBlacks < numOfBlacks)
                {
                    g.FillRectangle(bBlack, new Rectangle(r * 10, c * 10, (r + 1) * 10, (c + 1) * 10);
                    countNumOfBlacks++;
                }
                //else if(countNumOf... < numOf...)
                //{
                //    g.FillRectangle(b..., new Rectangle(r * 10, c * 10, (r + 1) * 10, (c + 1) * 10);
                //    countNumOf...++;
                //}
            }
        }
        bmp.Save("printedbitmap.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
