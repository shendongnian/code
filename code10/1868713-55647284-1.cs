    private async Task GetPreviewFrameAsSoftwareBitmapAsync()
    {
        // Get information about the preview
        var previewProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview) as VideoEncodingProperties;
    
        // Create the video frame to request a SoftwareBitmap preview frame
        var videoFrame = new VideoFrame(BitmapPixelFormat.Bgra8, (int)previewProperties.Width, (int)previewProperties.Height);
    
        // Capture the preview frame
        using (var currentFrame = await _mediaCapture.GetPreviewFrameAsync(videoFrame))
        {
            // Collect the resulting frame
            SoftwareBitmap previewFrame = currentFrame.SoftwareBitmap;
    
            // Show the frame information
            FrameInfoTextBlock.Text = String.Format("{0}x{1} {2}", previewFrame.PixelWidth, previewFrame.PixelHeight, previewFrame.BitmapPixelFormat);
    
            // Add a simple green filter effect to the SoftwareBitmap
            if (GreenEffectCheckBox.IsChecked == true)
            {
                ApplyGreenFilter(previewFrame);
            }
    
            // Show the frame (as is, no rotation is being applied)
            if (ShowFrameCheckBox.IsChecked == true)
            {
                // Create a SoftwareBitmapSource to display the SoftwareBitmap to the user
                var sbSource = new SoftwareBitmapSource();
                await sbSource.SetBitmapAsync(previewFrame);
    
                // Display it in the Image control
                PreviewFrameImage.Source = sbSource;
            }
          
        }
    }
