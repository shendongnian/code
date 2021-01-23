    foreach (var _item in listPhotoAlbum.Items)
    {
        var radioButton = _item as RadioButton;
        if (radioButton != null)
        {
            //Do with radioButton
            continue;
        }
        var button = _item as Button;
        if (button != null)
        {
            //Do with button
            continue;
        }
    }
