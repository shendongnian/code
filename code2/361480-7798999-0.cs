    public Image CapturedImage
    {
        set 
        { 
            pictureBoxCapturedImage.Image = value;
            panelCapturedImage.AutoScrollPosition = 
                new Point { 
                    X = (pictureBoxCapturedImage.Width - panelCapturedImage.Width) / 2, 
                    Y = (pictureBoxCapturedImage.Height - panelCapturedImage.Height) / 2 
                };
        }
    }
