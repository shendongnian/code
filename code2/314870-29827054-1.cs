        /// <summary>
        /// True if a window is completely visible 
        /// </summary>
        static bool WindowAllVisible(Rectangle windowRectangle)
        {
            int areaOfWindow = windowRectangle.Width * windowRectangle.Height;
            int areaVisible = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                Rectangle windowPortionOnScreen = screen.WorkingArea;
                windowPortionOnScreen.Intersect(windowRectangle);
                areaVisible += windowPortionOnScreen.Width * windowPortionOnScreen.Height;
                if (areaVisible >= areaOfWindow)
                {
                    return true;
                }
            }
            return false;
        }
