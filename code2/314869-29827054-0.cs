        /// <summary>
        /// True if a window is completely visible 
        /// </summary>
        static bool WindowAllVisible(Rectangle windowRectangle)
        {
            int areaOfWindow = windowRectangle.Width * windowRectangle.Height;
            int areaVisible = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                Rectangle formRectangleOnScreen = screen.WorkingArea;
                formRectangleOnScreen.Intersect(windowRectangle);
                areaVisible += formRectangleOnScreen.Width * formRectangleOnScreen.Height;
                if (areaVisible >= areaOfWindow)
                {
                    return true;
                }
            }
            return false;
        }
