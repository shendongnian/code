    //Reference to RegularExpressions
    using System.Text.RegularExpressions;
    ...
    //Code omitted...
    ...
    //Put the code in TextChanged event
    private void TextBoxResults_TextChanged(object sender, EventArgs e)
    {
        textBoxResults.Text = Regex.Replace(textBoxResults.Text, "[ab]", "");
    }
