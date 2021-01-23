        public static List<string> ParseTds(string input)
        {
            List<string> results = new List<string>();
            int index = 0;
            while (true)
            {
                string next = ParseTd(input, ref index);
                if (next == null)
                    return results;
                results.Add(next);
            }
        }
        private static string ParseTd(string input, ref int index)
        {
            int tdIndex = input.IndexOf("<td", index);
            if (tdIndex == -1)
                return null;
            int gtIndex = input.IndexOf(">", tdIndex);
            if (gtIndex == -1)
                return null;
            int endIndex = input.IndexOf("</td>", gtIndex);
            if (endIndex == -1)
                return null;
            index = endIndex;
            return input.Substring(gtIndex + 1, endIndex - gtIndex - 1);
        }
