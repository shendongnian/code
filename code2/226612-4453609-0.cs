    static string Repeat(string s, int length) {
            if (length < s.Length) {
                return s.Substring(0, length);
            }
            var list = new List<string>();
            StringBuilder t = new StringBuilder(s);
            do {
                string temp = t.ToString();
                list.Add(temp);
                t.Append(temp);
            } while(t.Length < length);
            int index = list.Count - 1;
            StringBuilder sb = new StringBuilder(length);
            while (sb.Length < length) {
                while (list[index].Length > length) {
                    index--;
                }
                if (list[index].Length <= length - sb.Length) {
                    sb.Append(list[index]);
                }
                else {
                    sb.Append(list[index].Substring(0, length - sb.Length));
                }
            }
            return sb.ToString();
        }
