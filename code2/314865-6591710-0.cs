        private void EnsureVisible(Control ctrl)
        {
            Rectangle ctrlRect = ctrl.DisplayRectangle; //The dimensions of the ctrl
            ctrlRect.Y = ctrl.Top; //Add in the real Top and Left Vals
            ctrlRect.X = ctrl.Left;
            Rectangle screenRect = Screen.GetWorkingArea(ctrl); //The Working Area fo the screen showing most of the Ctrl
            //Now tweak the ctrl's Top and Left until it's fully visible. 
            ctrl.Left += Math.Min(0, screenRect.Left + screenRect.Width - ctrl.Left - ctrl.Width);
            ctrl.Left -= Math.Min(0, ctrl.Left - screenRect.Left);
            ctrl.Top += Math.Min(0, screenRect.Top + screenRect.Height - ctrl.Top - ctrl.Height);
            ctrl.Top -= Math.Min(0, ctrl.Top - screenRect.Top);
        }
