        Line _selectedAxis = null;
        private void CanGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedAxis != null)
            {
                var line = _selectedAxis;
                var pos = e.GetPosition(line);
                textBlock.Text = $"({pos.X}, {pos.Y})";
                line.Y1 = pos.Y;
                line.Y2 = pos.Y;
            }
        }
        private void CanGraph_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _selectedAxis = null;
        }
        private void A_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var line = sender as Line;
            _selectedAxis = line;
        }
