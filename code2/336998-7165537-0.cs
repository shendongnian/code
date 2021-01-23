    String replacedString = textBox1.Text;
    for (i = 0; i <= 2; i++)
    {
       replacedString = replacedString.Replace(BadCharacters[i], GoodCharacters[i]);
    }
    textBox2.Text = replacedString;
