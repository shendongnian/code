    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_hitEllipse != null) {
            double newHitAngle = _hitEllipse.HitAngle(e.Location);
            double delta = newHitAngle - _hitAngle;
            if (Math.Abs(delta) > 0.0001) {
                _hitEllipse.Angle += (float)(delta * 180.0 / Math.PI);
                _hitAngle = newHitAngle;
                Invalidate();
            }
        }
    }
