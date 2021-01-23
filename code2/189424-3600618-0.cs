    bool isValidDate(string dtStr) {
        string pattern = @"^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$)"
        System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(pattern);
        return re.IsMatch(dtStr);
    }
     
