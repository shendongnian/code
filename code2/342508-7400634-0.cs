        public UXButton()
        {
            DefaultStyleKey = typeof(UXButton);
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPointCollection points = e.GetTouchPoints(null);
            foreach (TouchPoint point in points)
            {
                // specify what touch you want
                if (point.Action == TouchAction.Down)
                {
                    VisualStateManager.GoToState(this, "SpecialTouch", false);
                }
            }
        }
