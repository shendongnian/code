    const string input = @"abc class=""abcd abc zabc ab c"" abc"; 
 
    Regex regex = new Regex(string.Format(@"(?<=class\=""[^""]*\b){0}\b", "abc")); // I changed this line ?!! 
 
    string output = regex.Replace(input, "xyz");
 
    Assert.AreEqual(@"abc class=""abcd xyz zabc ab c"" abc", output); 
