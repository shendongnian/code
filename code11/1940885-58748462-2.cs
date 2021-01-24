    public static List<List<object>> ReadWithoutHeader(string file)
    {
        var list = new List<List<object>>();
        TextAsset data = Resources.Load (file) as TextAsset;
        var lines = Regex.Split (data.text, LINE_SPLIT_RE);
        if(lines.Length <= 1) return list;
        for(var i=0; i < lines.Length; i++) {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if(values.Length == 0 ||values[0] == "") continue;
            var entry = new List<object>();
            for(var j=0; j < values.Length; j++ ) {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if(int.TryParse(value, out n)) {
                    finalvalue = n;
                } else if (float.TryParse(value, out f)) {
                    finalvalue = f;
                }
                entry.Add(finalvalue);
            }
            list.Add(entry);
        }
        return list;
    }
