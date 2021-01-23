    PicureBox SelectedImage=null;
    void Image_Click(object sender,...)
    {
      SelectedImage=(PictureBox)sender;
      FocusProxy.Focus();
    }
    
    void FocusProxy_KeyDown(...)
    {
      if(e.KeyData==...)
      {
           SelectedImage.Image=null;
           e.Handled=true;
      }
    }
