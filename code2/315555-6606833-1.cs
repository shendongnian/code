    for(var i = 0; i < sprites.Length; i++)
    {
        PictureBox mainSprite = new PictureBox();
        mainSprite.Size = new Size(16, 16);
        mainSprite.Image = img;
        sprites[i] = mainSprite;
        ...
    }
