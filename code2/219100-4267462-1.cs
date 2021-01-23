    if (DoesImageExist(MyID)) {
        MyImg.ImageUrl = @"~/ShowImage.ashx?id=" + MyID;
        // Just in case we hid the image during a previous postback
        // and ViewState is enabled.
        MyImg.Visible = true;
    } else {
        MyImg.Visible = false;
    }
