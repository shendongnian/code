    var direction = 0;
    if (int.TryParse(DirectionTextBox.Text, out direction))
    {
        Move(direction);
        XTextBox.Text = X_Coordinate.ToString();
        YTextBox.Text = Y_Coordinate.ToString();
    }
    else
    {
        //handle invalid input, if not already done elsewhere.
    }
