    string s = "D4C1B2A3";
    
    var s1 = s.Where(c => char.IsLetter(c)).OrderBy(c => c).ToArray();
    var s2 = s.Where(c => char.IsDigit(c)).OrderBy(c => c).ToArray();
    
    var sortedString = new string(s.Select((x, idx) => idx % 2 == 0 ? s1[idx / 2] : s2[(idx - 1) / 2]).ToArray());
