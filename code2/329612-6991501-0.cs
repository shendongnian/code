    private void ChangePictureBoxImage(Image image)
    {
        pictureBox.Image.Dispose();//dispose the old image.
    
        pictureBox.Image = image;
    }
