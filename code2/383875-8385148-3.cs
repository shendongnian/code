    bool loggedIn = false;
    while (Reader.Read())
    {
        if (textBox4.Text == Reader.GetString(2))
        {
            string haspass= CryptorEngine.Encrypt(textBox5.Text, true);
            if (haspass == Reader.GetString(3))
            {
                loggedIn = true;
            }
        }
    }
    if (loggedIn)
    {
        MessageBox.Show("Successfully logged in!");
    }
    else
    {
        MessageBox.Show("Wrong Unhashed Username/Password Combination");
    }
