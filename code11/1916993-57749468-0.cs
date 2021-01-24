        private bool _mouseMoved;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MyTextBlock.Text = (await IfMouseMoved(TimeSpan.FromSeconds(4))).ToString();
        }
        private async Task<bool> IfMouseMoved(TimeSpan timeSpan)
        {
            MouseMove += MainWindow_MouseMove;
            try
            {
                _mouseMoved = false;
                await Task.Delay(timeSpan);
                return _mouseMoved;
            }
            finally
            {
                MouseMove -= MainWindow_MouseMove;
            }
        }
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseMoved = true;
        }
