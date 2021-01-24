            try
            {
                Canvas canvas = FullScreenCanvas.GetFullScreenCanvas();
                Sys.MouseManager.ScreenWidth = (uint)canvas.Mode.Columns;
                Sys.MouseManager.ScreenHeight = (uint)canvas.Mode.Rows;
                Pen pen = new Pen(Color.Red);
                int X = (int)Sys.MouseManager.X;
                int Y = (int)Sys.MouseManager.Y;
                canvas.DrawLine(pen, X, Y, X + 5, Y);
                canvas.DrawLine(pen, X, Y, X, Y - 5);
                canvas.DrawLine(pen, X, Y, X + 5, Y - 5);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
