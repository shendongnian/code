    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        foreach (Ellipse ellipse in _ellipses) {
            if (ellipse.IsHit(e.Location)) {
                _hitEllipse = ellipse;
                _hitAngle = ellipse.HitAngle(e.Location);
                break;
            }
        }
    }
