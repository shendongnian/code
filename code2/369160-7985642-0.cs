    bool[,] maze = new bool[2,2];
    maze[0, 0] = true;
    maze[0, 1] = false;
    maze[1, 0] = false;
    maze[1, 1] = true;
    const int squareWidth = 25;
    const int squareHeight = 25;
    using (Bitmap bmp = new Bitmap((maze.GetUpperBound(0) + 1) * squareWidth, (maze.GetUpperBound(1) + 1) * squareHeight))
    {
        using (Graphics gfx = Graphics.FromImage(bmp))
        {
            gfx.Clear(Color.Black);
            for (int y = 0; y <= maze.GetUpperBound(1); y++)
            {
                for (int x = 0; x <= maze.GetUpperBound(0); x++)
                {
                    if (maze[x, y])
                        gfx.FillRectangle(Brushes.White, new Rectangle(x * squareWidth, y * squareHeight, squareWidth, squareHeight));
                    else
                        gfx.FillRectangle(Brushes.Black, new Rectangle(x * squareWidth, y * squareHeight, squareWidth, squareHeight));
                }
            }
        }
        bmp.Save(@"c:\maze.bmp");
    }
