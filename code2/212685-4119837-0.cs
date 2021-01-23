            Bitmap objBitmap = new Bitmap("im.bmp");
            double[][] array = new double[objBitmap.Height][];
            for (int y = 0; y < objBitmap.Height; y++) {
                array[y] = new double[objBitmap.Width];
                for (int x = 0; x < objBitmap.Width; x++) {
                    Color col = objBitmap.GetPixel(x, y);
                    if (col == Color.White) array[y][x] = 1.0;
                    else if (col == Color.Black) array[y][x] = 0.0;
                    else array[y][x] = 0.5;  // whatever
                }
            }
            // Do something with array
            //...
