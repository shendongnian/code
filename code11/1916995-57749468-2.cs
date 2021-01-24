        private async Task<bool> IfMouseMoved(TimeSpan timeSpan)
        {
            var mouseMoved = false;
            void MouseMovedCallback(object sender, MouseEventArgs e)
            {
                mouseMoved = true;
            }
            MouseMove += MouseMovedCallback;
            try
            {
                await Task.Delay(timeSpan);
                return mouseMoved;
            }
            finally
            {
                MouseMove -= MouseMovedCallback;
            }
        }
