    GifFrame frame = gifDecoder.Frames[i];
    double frameRatio;
    if (frame.Height > frame.Width)
    {
       frameRatio = (double)OutputHeight / (double)frame.Height;
    }
    else
    {
       frameRatio = (double)OutputWidth / (double)frame.Width;
    }
    ...
    
    Point point = new Point((int)(frame.Location.X * frameRatio), (int)(frame.Location.Y * frameRatio));
