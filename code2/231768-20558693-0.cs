    public class JsonHelper
    {
        private const int INDENT_SIZE = 4;
        public static string FormatJson(string str)
        {
            var inserts = new List<int[]>();
            bool quoted = false, escape = false;
            str = (str ?? "").Replace("{}", @"\{\}").Replace("[]", @"\[\]");
            int depth = 0, N = str.Length;
            for (int i = 0; i < N; i++)
            {
                var chr = str[i];
                if (!escape && !quoted)
                    switch (chr)
                    {
                        case '{':
                        case '[':
                            inserts.Add(new[] { i, +1, 0, INDENT_SIZE * ++depth });
                            break;
                        case ',':
                            inserts.Add(new[] { i, +1, 0, INDENT_SIZE * depth });
                            break;
                        case '}':
                        case ']':
                            inserts.Add(new[] { i, -1, INDENT_SIZE * --depth, 0 });
                            break;
                        case ':':
                            inserts.Add(new[] { i, 0, 1, 1 });
                            break;
                    }
                quoted = (chr == '"') ? !quoted : quoted;
                escape = (chr == '\\') ? !escape : false;
            }
            N = inserts.Count;
            if (N > 0)
            {
                var sb = new System.Text.StringBuilder(str);
                while (--N >= 0)
                {
                    var insert = inserts[N];
                    int index = insert[0], before = insert[2], after = insert[3];
                    bool nlBefore = (insert[1] == -1), nlAfter = (insert[1] == +1);
                    if (after > 0) sb.Insert(index + 1, new String(' ', after));
                    if (nlAfter) sb.Insert(index + 1, Environment.NewLine);
                    if (before > 0) sb.Insert(index, new String(' ', before));
                    if (nlBefore) sb.Insert(index, Environment.NewLine);
                }
                str = sb.ToString();
            }
            return str.Replace(@"\{\}", "{}").Replace(@"\[\]", "[]");
        }
    }
