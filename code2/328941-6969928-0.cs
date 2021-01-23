    private void SomeTimer_Tick( ... )
    {
        UpdateAnimation();
    }
    
    private int _frameCount;
    private const int MaxFrames = //whatever, you need to determine this
    private void UpdateAnimation()
    {
        _frameCount = (_frameCount + 1) % MaxFrames;
        var image = GetFrame( _frameCount );
        // draw the new frame 
    }
    
    private const int FrameWidth = // again, you need to determine this
    private const int FrameHeight = // again, you need to determine this
    private Bitmap GetFrame( int frame )
    {
        // assumes frames are lined up horizontally on a sheet
        var rect = new Rectangle( frame * FrameWidth, 0, FrameWidth, FrameHeight );
    
        // you could create the frames up front to avoid many calls to Clone()
        return MySpriteSheet.Clone( rect, MySpriteSheet.PixelFormat );
    }
