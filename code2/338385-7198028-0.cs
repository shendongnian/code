    switch (rotateFlipType)
    {
        case Rotate90FlipNone:
            // Adjust rectangle to match new bitmap orientation
            rect = new Rectangle(bitmap.Height-rect.Bottom, 
                                 rect.Left,
                                 rect.Height,
                                 rect.Width);
            break;
        case RotateNoneFlipHorizontally:
            rect = new Rectangle(bitmap.Width - rect.Right,
                                 rect.Top,
                                 rect.Width,
                                 rect.Height);
            break;
        // ... etc.
    }
