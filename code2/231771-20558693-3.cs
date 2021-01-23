    public class JsonHelper
    {
        private const int INDENT_SIZE = 4;
        public static string FormatJson(string str)
        {
            str = (str ?? "").Replace("{}", @"\{\}").Replace("[]", @"\[\]");
            var inserts = new List<int[]>();
            bool quoted = false, escape = false;
            int depth = 0/*-1*/;
            for (int i = 0, N = str.Length; i < N; i++)
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
            if (inserts.Count > 0)
            {
                var sb = new System.Text.StringBuilder(str.Length * 2);
                int lastIndex = 0;
                foreach (var insert in inserts)
                {
                    int index = insert[0], before = insert[2], after = insert[3];
                    bool nlBefore = (insert[1] == -1), nlAfter = (insert[1] == +1);
                    sb.Append(str.Substring(lastIndex, index - lastIndex));
                    if (nlBefore) sb.AppendLine();
                    if (before > 0) sb.Append(new String(' ', before));
                    sb.Append(str[index]);
                    if (nlAfter) sb.AppendLine();
                    if (after > 0) sb.Append(new String(' ', after));
                    lastIndex = index + 1;
                }
                str = sb.ToString();
            }
            return str.Replace(@"\{\}", "{}").Replace(@"\[\]", "[]");
        }
    }
