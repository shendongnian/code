    public System.Drawing.Image GetThumbnailImage(int thumbWidth, int thumbHeight, System.Drawing.Image.GetThumbnailImageAbort callback, System.IntPtr callbackData)
        Member of System.Drawing.Image
    
    Summary:
    Returns a thumbnail for this System.Drawing.Image.
    
    Parameters:
    thumbWidth: The width, in pixels, of the requested thumbnail image.
    thumbHeight: The height, in pixels, of the requested thumbnail image.
    callback: A System.Drawing.Image.GetThumbnailImageAbort delegate. In GDI+ version 1.0, the delegate is not used. Even so, you must create a delegate and pass a reference to that delegate in this parameter.
    callbackData: Must be System.IntPtr.Zero.
    
    Returns:
    An System.Drawing.Image that represents the thumbnail.
