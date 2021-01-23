    yourTabControl.SelectedIndexChanged += (s, e) => {
        if (yourTabControl.SelectedIndex == 1)
            button1.Visible = false;
        } else {
            button1.Visible = true;
        }
    };
