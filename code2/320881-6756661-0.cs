    // put this somewhere in initialization
    private void Init() 
    {
        Image image = Resources.Progress16;
        _dimension = new FrameDimension(image.FrameDimensionsList[0]);
        _frameCount = image.GetFrameCount(_dimension);
        image.SelectActiveFrame(_dimension, _activeFrame);
        Image = image;
    }
    private void TickImage()
    {
        if (_stop) return;
        // get next frame index
        if (++_activeFrame >= _frameCount)
        {
            _activeFrame = 0;
        }
        // switch image frame
        Image.SelectActiveFrame(_dimension, _activeFrame);
        // force refresh (NOTE: check if it's really needed)
        Invalidate();
    }
