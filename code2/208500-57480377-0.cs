        //center a window on chosen screen
        public static void CenterWindow(Window w, System.Windows.Forms.Screen screen = null)
        {
            if(screen == null)
                screen = System.Windows.Forms.Screen.PrimaryScreen;
            int screenW = screen.Bounds.Width;
            int screenH = screen.Bounds.Height;
            int screenTop = screen.Bounds.Top;
            int screenLeft = screen.Bounds.Left;
            w.Left = PixelsToPoints((int)(screenLeft + (screenW - PointsToPixels(w.Width, "X")) / 2), "X");
            w.Top = PixelsToPoints((int)(screenTop + (screenH - PointsToPixels(w.Height, "Y")) / 2), "Y");
        }
        public static double PixelsToPoints(int pixels, string direction)
        {
            if (direction == "X")
            {
                return pixels * SystemParameters.WorkArea.Width / System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            }
            else
            {
                return pixels * SystemParameters.WorkArea.Height / System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            }
        }
        public static double PointsToPixels(double wpfPoints, string direction)
        {
            if (direction == "X")
            {
                return wpfPoints * System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.WorkArea.Width;
            }
            else
            {
                return wpfPoints * System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.WorkArea.Height;
            }
        }
