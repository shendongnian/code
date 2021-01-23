    public Size NewImageSize(int OriginalHeight, int OriginalWidth, double FormatSize)
    		{
    			Size NewSize;
    			double tempval;
    
    			if (OriginalHeight > FormatSize && OriginalWidth > FormatSize)
    			{
    				if (OriginalHeight > OriginalWidth)
    					tempval = FormatSize / Convert.ToDouble(OriginalHeight);
    				else
    					tempval = FormatSize / Convert.ToDouble(OriginalWidth);
    
    				NewSize = new Size(Convert.ToInt32(tempval * OriginalWidth), Convert.ToInt32(tempval * OriginalHeight));
    			}
    			else
    				NewSize = new Size(OriginalWidth, OriginalHeight); return NewSize;
    		} 
    
    		private bool save_image_with_thumb(string image_name, string path)
    		{
    			
    				ResimFileUpload1.SaveAs(path + image_name + ".jpg"); //normal resim kaydet
    			
    			
    
    			///////Thumbnail yarat ve kaydet//////////////
    			try
    			{
    				Bitmap myBitmap;
    
    				myBitmap = new Bitmap(path + image_name + ".jpg");
    
    				Size thumbsize = NewImageSize(myBitmap.Height, myBitmap.Width, 100);
    
    				System.Drawing.Image.GetThumbnailImageAbort myCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
    
    				// If jpg file is a jpeg, create a thumbnail filename that is unique.
    
    				string sThumbFile = path + image_name + "_t.jpg";
    
    				// Save thumbnail and output it onto the webpage
    
    				System.Drawing.Image myThumbnail = myBitmap.GetThumbnailImage(thumbsize.Width, thumbsize.Height, myCallBack, IntPtr.Zero);
    
    				myThumbnail.Save(sThumbFile);
    
    				// Destroy objects
    				myThumbnail.Dispose();
    				myBitmap.Dispose();
    
    				return true;
    			}
    			catch //yaratamazsa normal ve thumb iptal
    			{
    				return false;
    			}
    			///////////////////////////////////
    
    		}
