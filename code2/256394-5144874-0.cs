    List<string>lines = s.Split(new string[]{ Environment.NewLine },
                                StringSplitOptions.None)
                         .ToList();
    lines.RemoveAt(1);
    // Note: In .NET 4.0 the ToArray call is not required.
    string result = string.Join(Environment.NewLine, lines.ToArray());
