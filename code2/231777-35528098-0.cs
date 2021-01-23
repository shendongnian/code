        public static string JsonFormatter(string json)
        {
            StringBuilder builder = new StringBuilder();
            
            bool quotes = false;
            bool ignore = false;
            int offset = 0;
            int position = 0;
            if (string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }
            json = json.Replace(Environment.NewLine, "").Replace("\t", "");
            foreach (char character in json)
            {
                switch (character)
                {
                    case '"':
                        if (!ignore)
                        {
                            quotes = !quotes;
                        }
                        break;
                    case '\'':
                        if (quotes)
                        {
                            ignore = !ignore;
                        }
                        break;
                }
                if (quotes)
                {
                    builder.Append(character);
                }
                else
                {
                    switch (character)
                    {
                        case '{':
                        case '[':
                            builder.Append(character);
                            builder.Append(Environment.NewLine);
                            builder.Append(new string(' ', ++offset * 4));
                            break;
                        case '}':
                        case ']':
                            builder.Append(Environment.NewLine);
                            builder.Append(new string(' ', --offset * 4));
                            builder.Append(character);
                            break;
                        case ',':
                            builder.Append(character);
                            builder.Append(Environment.NewLine);
                            builder.Append(new string(' ', offset * 4));
                            break;
                        case ':':
                            builder.Append(character);
                            builder.Append(' ');
                            break;
                        default:
                            if (character != ' ')
                            {
                                builder.Append(character);
                            }
                            break;
                    }
                    position++;
                }
            }
            return builder.ToString().Trim();
        }
