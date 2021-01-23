    foreach (ImageButton button in parent.Controls
                                         .OfType<ImageButton>()
                                         .Where(c => c.ID == null))
    {
        button.ImageUrl = @"pictures/close-icon.png";
        buttonID = "Imagebtn" + count;
        button.Click += new UserControl1_ImageButtonClickEvent;
    }
