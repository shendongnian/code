    string firstText = "Hello";
    string secondText = "World";
    
    PointF firstLocation = new PointF(10f, 10f);
    PointF secondLocation = new PointF(10f, 50f);
    
    string imageFilePath = @"path\picture.bmp";
    
    Bitmap newBitmap;
    using (var bitmap = (Bitmap)Image.FromFile(imageFilePath))//load the image file
    {
    	using(Graphics graphics = Graphics.FromImage(bitmap))
    	{
    		using (Font arialFont =  new Font("Arial", 10))
    		{
    			graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
    			graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
    		}
    	}
    	newBitmap = new Bitmap(bitmap);
    }
    
    newBitmap.Save(imageFilePath);//save the image file
    newBitmap.Dispose();
