        public UXButton()
        {
            DefaultStyleKey = typeof(UXButton);
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            // UPDATE: get the Grid
            var wrapper = GetTemplateChild("Wrapper") as Grid;
            TouchPointCollection points = e.GetTouchPoints(null);
            foreach (TouchPoint point in points)
            {
                // UPDATE: also do the touch area check here
                // specify what touch you want
                if (point.Action == TouchAction.Down && point.TouchDevice.DirectlyOver == wrapper)
                {
                    VisualStateManager.GoToState(this, "SpecialTouch", false);
                }
            }
        }
