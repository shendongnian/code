        /// <summary>
        ///     Reads a string literal from a file, essentially implementing the regex pattern /\"{.*}\"/.
        ///     Ignores escape characters (for instance, "\"" will fail)
        /// </summary>
        /// <param name="fs">The file stream to read from.</param>
        /// <returns>The string literal without it's quotes upon success, null otherwise.</returns>
        static string ReadString(FileStream fs)
        {
            if (!fs.CanRead)
                return null; // cant read from stream, throw an exception here
            var reader = new StreamReader(fs);
            var sb = new StringBuilder();
            bool inString = false;
            while (true)
            {
                if (reader.Peek() < 0)
                    return null; // reached EOF before string ended, throw exception here
                char ch = (char)reader.Read();
                if (inString)
                    if (ch == '"')
                        break;
                    else
                        sb.Append(ch);
                else
                    if (ch == '"')
                        inString = true;
                    else if (!char.IsWhiteSpace(ch))
                        return null; // string does not start with quote, throw exception here
            }
            return sb.ToString();
        }
