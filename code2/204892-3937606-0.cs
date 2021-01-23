        var strings = new List<string>()
                        {
                            "82&?",
                            "82,9",
                            "abse82,9>dpkg"
                        };
        var reg = new Regex("[^0-9,]*", RegexOptions.None);
        var output = new List<string>();
        foreach(var str in strings)
        {
            output.Add(reg.Replace(str, ""));
        }
