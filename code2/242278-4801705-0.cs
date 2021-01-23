        private static string ToTable(string input)
        {
            var result = new StringBuilder(input.Length * 2);
            result.AppendLine("<table>");
            foreach (var row in input.Split('|'))
            {
                result.Append("<tr>");
                foreach (var cell in row.Split(','))
                    result.AppendFormat("<td>{0}</td>", cell);
                result.AppendLine("/<tr>");
            }
            result.AppendLine("</table>");
            return result.ToString();
        }
