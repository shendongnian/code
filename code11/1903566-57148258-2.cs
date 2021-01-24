    private void btn_BROWSE_Click(object sender, EventArgs e)
    {
        OpenFileDialog imge = new OpenFileDialog(); 
        imge.Filter = "Extensions |*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|"
                      + "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|"
                      + "Zip Files|*.zip;*.rar";
        imge.ShowDialog(); 
        string imgepath = imge.FileName;
        pBox_SOURCE.ImageLocation = imgepath;//i'm browsing an image
        
        //save the image to the container
        ImageContainer.Image = new Bitmap(pBox_SOURCE.Image);
    }
    private void sliderKernel_MouseUp(object sender, MouseEventArgs e)
    {
        Filter filter = new SliderKernel () { Image = ImageContainer.Image };
        filter.Apply();
    } 
