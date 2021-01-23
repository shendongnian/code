    using System.Text.RegularExpressions;
    
    string input = "hello hi HELLO hi HI";
    MatchCollection matches = Regex.Matches(input, @" [A-Z]* ");
    foreach (Match m in matches)
    {
        MessageBox.Show(m.Value);
    }
