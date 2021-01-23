    static bool isDigitsFr(string s) { if (s == null || s == "") return false; for (int i = 0; i < s.Length; i++) if (s[i] < '0' || s[i] > '9') return false; return true; }
    static bool isDigitsFu(string s) { if (s == null || s == "") return false; for (int i = 0; i < s.Length; i++) if ((uint)(s[i] - '0') > 9) return false; return true; }
    static bool isDigitsFx(string s) { if (s == null || s == "") return false; for (int i = 0; i < s.Length; i++) if ((s[i] ^ '0') > 9) return false; return true; }
    static bool isDigitsEr(string s) { if (s == null || s == "") return false; foreach (char c in s) if (c < '0' || c > '9') return false; return true; }
    static bool isDigitsEu(string s) { if (s == null || s == "") return false; foreach (char c in s) if ((uint)(c - '0') > 9) return false; return true; }
    static bool isDigitsEx(string s) { if (s == null || s == "") return false; foreach (char c in s) if ((c ^ '0') > 9) return false; return true; }
    static void test()
    {
        var w = new Stopwatch(); bool b; var s = int.MaxValue + ""; int r = 12345678*2; var ss = new SortedSet<string>(); //s = string.Concat(Enumerable.Range(0, 127).Select(i => ((char)i ^ '0') < 10 ? 1 : 0));
        w.Restart(); for (int i = 0; i < r; i++) b = s.All(char.IsDigit); w.Stop(); ss.Add(w.Elapsed + ".All .IsDigit"); 
        w.Restart(); for (int i = 0; i < r; i++) b = s.All(c => c >= '0' && c <= '9'); w.Stop(); ss.Add(w.Elapsed + ".All <>"); 
        w.Restart(); for (int i = 0; i < r; i++) b = s.All(c => (c ^ '0') < 10); w.Stop(); ss.Add(w.Elapsed + " .All ^"); 
        w.Restart(); for (int i = 0; i < r; i++) b = isDigitsFr(s); w.Stop(); ss.Add(w.Elapsed + " for     <>");
        w.Restart(); for (int i = 0; i < r; i++) b = isDigitsFu(s); w.Stop(); ss.Add(w.Elapsed + " for     -");
        w.Restart(); for (int i = 0; i < r; i++) b = isDigitsFx(s); w.Stop(); ss.Add(w.Elapsed + " for     ^");
        w.Restart(); for (int i = 0; i < r; i++) b = isDigitsEr(s); w.Stop(); ss.Add(w.Elapsed + " foreach <>");
        w.Restart(); for (int i = 0; i < r; i++) b = isDigitsEu(s); w.Stop(); ss.Add(w.Elapsed + " foreach -");
        w.Restart(); for (int i = 0; i < r; i++) b = isDigitsEx(s); w.Stop(); ss.Add(w.Elapsed + " foreach ^");
        MessageBox.Show(string.Join("\n", ss)); return;
    }
