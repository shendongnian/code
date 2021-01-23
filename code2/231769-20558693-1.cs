            int depth = -1, N = str.Length;
            ...
                    switch (chr)
                    {
                        case '{':
                        case '[':
                            int n = (i == 0 || "{[,".Contains(str[i - 1])) ? 0 : -1;
                            inserts.Add(new[] { i, n, INDENT_SIZE * ++depth * -n, INDENT_SIZE - 1 });
                            break;
                        case ',':
                            inserts.Add(new[] { i, -1, INDENT_SIZE * depth, INDENT_SIZE - 1 });
                            break;
                        case '}':
                        case ']':
                            inserts.Add(new[] { i, -1, INDENT_SIZE * depth--, 0 });
                            break;
                        case ':':
                            inserts.Add(new[] { i, 0, 1, 1 });
                            break;
                    }
