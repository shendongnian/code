    private void PictureEditorOnMouseMove(Object sender, MouseEventArgs e)
    {   
        PictureEdit pce = sender as PictureEdit;         
        if(e.Button == MouseButtons.Left)
        {
            (this.pictureEditor.Image as Bitmap).SetPixel(e.X - pce.Location.X, e.Y - pce.Location.Y, this.colorPicker.Color);                                    
        }
    }
