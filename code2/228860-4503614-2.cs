    string s = @"$KUH% I*$)OFNlkfn$";
    var withoutSpecial = new string(s.Where(c => Char.IsLetterOrDigit(c) 
                                                || Char.IsWhiteSpace(c)).ToArray());
            
    if (s != withoutSpecial)
    {
        Console.WriteLine("String contains special chars");
    }
