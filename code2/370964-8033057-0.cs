        int score = 0;
        if (txtPass.Text.Length < 4)
            score += 1;
        if (txtPass.Text.Length >= 6)
            score += 4;
        if (txtPass.Text.Length >= 12)
            score += 5;
        if (Regex.IsMatch(PassChar, @"[a-z]") && Regex.IsMatch(PassChar, @"[A-Z]"))
            score += 2;
        if (Regex.IsMatch(PassChar, @"[!@#\$%\^&\*\?_~\-\(\);\.\+:]+"))
            score += 3;
        if (score < 2) {
           color = Color.Red;
        } else if (score < 6) {
           color = Color.Yellow;
        } else if (score < 12) {
           color = Color.YellowGreen;
        } else {
           color = Color.Green;
        }
