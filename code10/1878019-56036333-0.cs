    string escapedString = MySql.Data.MySqlClient.MySqlHelper.EscapeString(textBox1.Text);
    
    // Do some more validations, what text you got before building you column..
    if (!new Regex("[a-zA-z]+").IsMatch(escapedString))
        throw new Exception();
    MySqlCommand command = new MySqlCommand("ALTER TABLE Students ADD COLUMN " + excapedString + " TEXT", sqlConnection);
