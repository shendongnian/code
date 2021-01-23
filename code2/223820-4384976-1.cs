    string s = "1 STATE OF GOA THROUGH CHIEF";
    bool sawLetter = false;
    StringBuilder sb = new StringBuilder(s.Length);
    foreach (char c in s) {
        if (!sawLetter && Char.IsLetter(c)) {
            sb.Append(Char.ToUpperInvariant(c));
            sawLetter = true;
        }
        else {
            sb.Append(Char.ToLowerInvariant(c));
        }
    }
    Console.WriteLine(sb.ToString());
