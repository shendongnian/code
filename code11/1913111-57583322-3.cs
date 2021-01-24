    private void button1_Click(object sender, EventArgs e)
    {
        // For each line in the first RTB
        foreach (string line in richTextBox1.Lines)
        {
            // Create a 'UserInfo' instance from the line using the 'Parse' method
            var userInfo = UserInfo.Parse(line);
            // Add the string result of that instance to the second RTB
            richTextBox2.AppendText(userInfo + Environment.NewLine);
            // Or you can do other things now, with:
            // userInfo.UserName and userInfo.Password
        }
    }
