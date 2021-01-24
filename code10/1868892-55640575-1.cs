        private bool _toolTipShown = false;
        private bool IsTransparent(PictureBox pb, MouseEventArgs e)
        {
            Color pixel = ((Bitmap)pb.Image).GetPixel(e.X, e.Y);
            return (0 == pixel.A && 0 == pixel.R && 0 == pixel.G && 0 == pixel.B);
        }
        private void DisplayToolTip(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            IsTransparent((PictureBox)control, e);
            if (IsTransparent((PictureBox)control, e))
            {
                _toolTip.Hide(control);
                _toolTipShown = false;
            }
            else
            {
                if (!_toolTipShown)
                {
                    _toolTip.Show(control.Tag.ToString(), control);
                    _toolTipShown = true;
                }
            }
        }
