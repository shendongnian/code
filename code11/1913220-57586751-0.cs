    String Prefix = "Favour";
    String Suffix = "valley";
    String RegexForm = String.Format(@"(?<={0}\s).*(?=\s{1})", Prefix, Suffix);
    Regex r = new Regex(RegexForm, RegexOptions.Compiled);
    String Data = "Arrived totally in as between private. Favour of so as on pretty though elinor direct. Reasonable estimating be alteration we themselves entreaties me of reasonably. Direct wished so be expect polite valley. Whose asked stand it sense no spoil to. Prudent you too his conduct feeling limited and. Side he lose paid as hope so face upon be. Goodness did suitable learning put.";
    Match m = r.Match(Data);
    Console.WriteLine("Match => " + Prefix + m.Value + Suffix);
