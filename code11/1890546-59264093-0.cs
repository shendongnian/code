    using Emgu.CV;
    
    ...
    
    	private void StartWatching()
    	{
    		Task.Run(() =>
    		{
    			try
    			{
    				capture = new VideoCapture(headConfiguration.CameraStreamingUri.ToString());
    				capture.ImageGrabbed += Capture_ImageGrabbed;
    				capture.Start(ExceptionHandler.AlwaysHandle);
    			}
    			catch (Exception ex)
    			{
    				capture = null;
    				Logger.Error(ex);
    				throw ex;
    			}
    		});
    	}
    
    	private void Capture_ImageGrabbed(object sender, EventArgs e)
    	{
    		if (capture == null || OnNewCameraFrame == null)
    		{
    			return;
    		}
    
    		try
    		{
    			var frame = new Mat();
    			if (capture.Retrieve(frame))
    			{
    				var output = new ByteImage(frame.Width, frame.Height, frame.Step);
    
    				Marshal.Copy(frame.DataPointer, output.Data, 0, output.Height * output.Stride);
    				
    				OnNewCameraFrame?.Invoke(this, new ValueChangeArgs<ByteImage>(output));
    			}
    		}
    		catch (Exception ex)
    		{
    			Logger.Error(ex);
    		}
    	}
