    if (String.IsNullOrEmpty(MyID)) {
        MyImg.Visible = false;
    } else {
        MyImg.ImageUrl = @"~/ShowImage.ashx?id=" + MyID;
        // Just in case we hid the image during a previous postback
        // and ViewState is enabled.
        MyImg.Visible = true;
    }
