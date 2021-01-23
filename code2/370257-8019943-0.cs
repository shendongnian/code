    public void TestWaterShed()
    	      {  
    	         Image<Bgr, Byte> image = new Image<Bgr, byte>("myImage.jpg");                 
    	         Image<Gray, Int32> marker = new Image<Gray, Int32>(image.Width, image.Height);
    	         Rectangle rect = image.ROI;
    	         marker.Draw(
    	            new CircleF(
    	               new PointF(rect.Left + rect.Width / 2.0f, rect.Top + rect.Height / 2.0f),
    	               (float)(Math.Min(image.Width, image.Height) / 4.0f)),
    	            new Gray(255),
    	            0);
    	         CvInvoke.cvWatershed(image, marker);
    	      }
