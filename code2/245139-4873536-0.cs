        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (_graphics != null)
            {
                _graphics.DrawImage(_original, 0, 0);
                _graphics.DrawEllipse(_whitePen, pos.X, pos.Y, 10, 10);
                picCanvas.Invalidate();
            }
        }
