    MessageBox.Show(this,
                    "You have not inputted a username or password. Would you like to configure your settings now?",
                    "Settings Needed",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,  // specify "Yes" as the default
                    (MessageBoxOptions)0x40000);      // specify MB_TOPMOST
