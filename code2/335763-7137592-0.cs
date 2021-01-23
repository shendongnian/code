        private static string ProcessLine(string line, int seconds)
        {
            var regex = new Regex(@"^(\d\d:\d\d:\d\d,\d\d\d) --> (\d\d:\d\d:\d\d,\d\d\d)");
            var match = regex.Match(line);
            if (match.Success)
            {
                var from = AddSeconds(match.Groups[1].ToString(), seconds);
                var to = AddSeconds(match.Groups[2].ToString(), seconds);
                return string.Format("{0} --> {1}", from, to);
            }
            else
            {
                return line;
            }
        }
        private static string AddSeconds(string timestamp, int seconds)
        {
            var datetime = DateTime.ParseExact(timestamp, "HH:mm:ss,fff", CultureInfo.InvariantCulture);
            return datetime.AddSeconds(seconds).ToString("HH:mm:ss,fff"); 
        }
