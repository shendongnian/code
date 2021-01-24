    string HWIDList = HWIDReader.DownloadString("/*the link would be here, can't share it*/");
    string[] lines = HWIDList.Split('\n');
    // NOTE: Should create a hash from the password and compare to saved password hashes 
    // so that nobody knows what the users' passwords are
    string userInput = string.Format("{0}:{1};", usernameBox.Text, passwordBox.Text);
    foreach (string pair in lines)
    {
        if (pair != userInput)
            continue;
        // found match: do stuff
    }
