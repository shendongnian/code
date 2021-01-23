    public class JsonHelper
    {
        private const int INDENT_SIZE = 4;
        public static string FormatJson(string str)
        {
            str = (str ?? "").Replace("{}", @"\{\}").Replace("[]", @"\[\]");
            var inserts = new List<int[]>();
            bool quoted = false, escape = false;
            int depth = 0/*-1*/, N = str.Length;
            for (int i = 0; i < N; i++)
            {
                var chr = str[i];
                if (!escape && !quoted)
                    switch (chr)
                    {
                        case '{':
                        case '[':
                            inserts.Add(new[] { i, +1, 0, INDENT_SIZE * ++depth });
                            //int n = (i == 0 || "{[,".Contains(str[i - 1])) ? 0 : -1;
                            //inserts.Add(new[] { i, n, INDENT_SIZE * ++depth * -n, INDENT_SIZE - 1 });
                            break;
                        case ',':
                            inserts.Add(new[] { i, +1, 0, INDENT_SIZE * depth });
                            //inserts.Add(new[] { i, -1, INDENT_SIZE * depth, INDENT_SIZE - 1 });
                            break;
                        case '}':
                        case ']':
                            inserts.Add(new[] { i, -1, INDENT_SIZE * --depth, 0 });
                            //inserts.Add(new[] { i, -1, INDENT_SIZE * depth--, 0 });
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
