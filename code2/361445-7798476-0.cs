        void btMouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown) {
                int deltaX = e.X - _mousePos.X;
                int deltaY = e.Y - _mousePos.Y;
                panel2.Location = new Point(panel2.Left + deltaX, panel2.Top /* + deltaY */);
            }
        }
