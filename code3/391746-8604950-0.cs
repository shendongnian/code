    private void button1_Click(object sender, EventArgs e)
    {
        Regex exp = new Regex(@"(\d{3})(\d{3})(\d{3})(\d{2})");
        string s = "01234567890";
         string newS = exp.Replace(s, new MatchEvaluator(doIt));
         newS += "";
    }
    private string doIt(Match m)
    {
        return m.Groups[1] + "." + m.Groups[2] + "." + m.Groups[3] + "-" + m.Groups[4];
    }
