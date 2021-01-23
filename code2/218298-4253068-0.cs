    public static void NavigatePicture(int direction)
    {
    	if (arrayPosition + direction >= 0 && arrayPosition + direction < numFiles)
    	{
    		arrayPosition += direction;
    		_formInstance.SetPictureLocation(arrayPictures[arrayPosition, 0]);
    		
    		_formInstance.SetCopyStatus(Convert.ToBoolean(arrayPictures[arrayPosition, 1]));
    		_formInstance.SetDeleteStatus(Convert.ToBoolean(arrayPictures[arrayPosition, 2]));
    	}
    }
    
    
    //...and in the form:
    public SetPictureLocation(sLocation)
    {
    	myPictureBox.ImageLocation = sLocation;
    }
