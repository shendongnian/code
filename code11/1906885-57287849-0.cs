    var searchWord = "strong";
    var mail = "<strong>blablabla</strong><p>blabla strong blabla</p>";
    var rgx = new Regex($"(?!<){searchWord}(?!>)"); // Will match strong but not <strong> or <strong or strong>
    if (rgx.IsMatch(mail))
    {
        // Do what you want
    }
