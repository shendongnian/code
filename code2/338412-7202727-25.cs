    Image<Gray, Byte> My_Image = new Image<Gray, byte>(openfile.FileName);
    Image<Gray, Byte> My_Image_Copy = My_Image.CopyBlank();
    
    Rectangle Store_ROI = my_image.ROI; //Only need one as both images same size
    
    My_Image.ROI = new Rectangle(50, 50, 100, 100);
    My_Image_Copy.ROI = new Rectangle(50, 50, 100, 100);
    
    My_Image_Copy = My_Image.Copy(); //This will only copy the Region Of Interest
    //Reset the Regions Of Interest so you will now operate on the whole image 
    My_Image.ROI = Store_ROI;
    My_Image_Copy.ROI = Store_ROI;
