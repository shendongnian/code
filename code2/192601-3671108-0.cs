    public static Regex NumInpRegex = new Regex(
          "^(?<inp_num>\\d+)$",
        RegexOptions.IgnoreCase
        | RegexOptions.Singleline
        | RegexOptions.ExplicitCapture
        | RegexOptions.CultureInvariant
        | RegexOptions.IgnorePatternWhitespace
        | RegexOptions.Compiled
        );
    string InputText = Console.ReadLine();
    Match m = NumInpRegex.Match(InputText);
    if (m.Success && InputText.Length > 0){
        betAmount = int.Parse(m.Groups["inp_num"].Value);
        Console.WriteLine(_chips - betAmount);
    }
