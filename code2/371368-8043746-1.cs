    void Main() {
        var s = ToBinary("BOB");
    }
    string ToBinary(string s) {
        var r = "";
        foreach (var c in s.ToCharArray()) {
            string w = "";
            for (int i = 1; i < 257; i = i << 1)
                w = ((c & i) > 0 ? "1" : "0") + w;
            r += "[" + w + "]";
        }
        return r;
    }
