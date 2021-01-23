    Regex socialSecurityNumberCheck = new Regex(Pattern.With.AtBeginning
        .Digit.Repeat.Exactly(3)
        .Literal("-").Repeat.Optional
        .Digit.Repeat.Exactly(2)
        .Literal("-").Repeat.Optional
        .Digit.Repeat.Exactly(4)
        .AtEnd);
