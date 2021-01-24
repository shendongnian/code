    const int subScriptBase = 0x2080;
    string chem = "C6H12Cl";
    // Or this.Title, in WPF
    this.Text = chem.Aggregate(new StringBuilder(), (sb, c) => 
        sb.Append(char.IsDigit(c) ? (char)(subScriptBase + c - 48) : c)).ToString();
