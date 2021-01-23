    myTextBox.IsKeyboardFocusedChanged += myTextBox_IsKeyboardFocusedChanged;
    private void SendFileCaptionTextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue.ToString() == "True")
        {
            // it's focused
        }
        else
        {
            // it's not focused
        }
    }    
