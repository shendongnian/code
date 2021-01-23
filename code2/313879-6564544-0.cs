    public static bool IsInt(string s) {
        bool isInt = true;
        for (int i = 0; i < s.Length; i++) {
            if (!char.IsDigit(s[i])) {
                isInt = false;
                break;
            }
        }
        return isInt;
    }
