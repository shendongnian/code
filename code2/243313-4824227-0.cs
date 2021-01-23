    private readonly object myLock = new object();
    ...
    
    
    if (picImage != null)
    {
       lock(myLock)
       {
          this.picLiveView.Image = (System.Drawing.Image)picImage.Clone();
       }
    } 
