    private void test()
    {
        string t = @"<a href=""image-CoRRECTME.aspx?ALSO=ME&leaveme=<%= MyClass.Text %>&test2=<%= MyClass2.Text %>&last_test=nothing"">somelink</a>";
        string fixed_string = Regex.Replace(t, "(?<=href=\"|%>)([^\"]*?)(?=<%|\")", TestMatchEvaluator);
    }
    private string TestMatchEvaluator(Match m)
    {
        return m.Value.ToLower();
    }
