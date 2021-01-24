c#
static void Main(string[] args)
{
    string someText = "AAAAAAAAAA sjkvsvkjq BBBBBBBBBBB";
    // This is how to find a Text within a String:
    string searchText = "BBBBBBBBBBB";
    int indexOfString = someText.IndexOf(searchText);
    Console.WriteLine("Text found at index " + indexOfString);
    // This is how to find text within a pattern:
    Regex regularExpression = new Regex("AAAAAAAAAA (.*) BBBBBBBBBBB");
    string textBetweenBraces = regularExpression.Match(someText).Groups[1].ToString();
    Console.WriteLine("Pattern matched. Text in Pattern: " + textBetweenBraces);
    // Paint your cell:
    if (regularExpression.IsMatch(someText))
    {
        DataGridViewTextBoxCell cell = null; // Select your cell
        cell.Style.BackColor = Color.Red;
    }
}
