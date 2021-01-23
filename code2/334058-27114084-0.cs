    float ViewportWidth = graphicsDevice.Viewport.Width;
    float ViewportHeight = graphicsDevice.Viewport.Height;
    
    Matrix scale = Matrix.CreateScale(zoom, zoom, 0);
    Matrix inputScalar = Matrix.Invert(scale);
    ...
    public MouseState transformMouse(MouseState mouse)
    {
        /// Shifts the position to 0-relative
        Vector2 newPosition = new Vector2(mouse.X - ViewportWidth,
                                          mouse.Y - ViewportHeight);
        /// Scales the input to a proper size
        newPosition = Vector2.Transform(newPosition, InputScalar);
        return new MouseState((int)newPosition.X, (int)newPosition.Y,
                              mouse.ScrollWheelValue, mouse.LeftButton,
                              mouse.MiddleButton, mouse.RightButton,
                              mouse.XButton1, mouse.XButton2);
    }
