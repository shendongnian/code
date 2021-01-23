    // Display popup expecting a DialogResult.OK or DialogResult.Cancel
    void ShowPopup ( )
    {
        MyPopup popup = new MyPopup ( );
        if (popup.ShowDialog() == DialogResult.OK)
        {
            //  process popup textbox text values
        }
        else
        {
            //  process popup cancel action
        }
    }
