    private void CanvasOnMouseMove(object sender, MouseEventArgs e)
    {
        if (_isDraggingDot)
        {
            var mousePos = e.GetPosition(canvas);
            var x = mousePos.X;
            if (x < 0)
            {
                x = 0;
            }
            if (x > canvas.Width)
            {
                x = canvas.Width;
            }
            var y = mousePos.Y;
            if (y < 0)
            {
                y = 0;
            }
            if (y > canvas.Height)
            {
                y = canvas.Height;
            }
            dot.SetValue(Canvas.LeftProperty, x - (dot.Width / 2.0)); // offset ensures dot is centred on mouse pointer
            dot.SetValue(Canvas.TopProperty, y - (dot.Height / 2.0));
            }
        }
