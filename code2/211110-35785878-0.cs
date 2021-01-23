    List<string> lines = new List<string> {
        "line1",
        "line2",
        String.Format("{0} - {1} | {2}", 
            someVar,
            othervar, 
            thirdVar
        )
    };
    if(foo)
        lines.Add("line3");
    return String.Join(Environment.NewLine, lines);
