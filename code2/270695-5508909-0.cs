    var mailingMergeString = new MailingMergeString(input);
    var output = mailingMergeString.ParseMailingMergeString();
    public class MailingMergeString
    {
        private string _input;
        public MailingMergeString(string input)
        {
            _input = input;
        }
        public string ParseMailingMergeString()
        {
            IList<SqlReplaceCommand> sqlCommands = new List<SqlReplaceCommand>();
            var i = 0;
            const string openBrace = "{";
            const string closeBrace = "}";
            while (string.IsNullOrWhiteSpace(_input) == false)
            {
                var open = _input.IndexOf(openBrace) + 1;
                var close = _input.IndexOf(closeBrace);
                var length = close != -1 ? close - open : _input.Length;
                var newInput = _input.Substring(close + 1);
                var nextClose = newInput.Contains(openBrace) ? newInput.IndexOf(openBrace) : newInput.Length;
                var sqlReplaceCommand = new SqlReplaceCommand
                {
                    Command = _input.Substring(open, length),
                    PlaceHolder = openBrace + i + closeBrace,
                    Text = _input.Substring(close + 1, nextClose),
                    NewInput = _input.Substring(close + 1)
                };
                sqlCommands.Add(sqlReplaceCommand);
                i++;
                _input = newInput.Contains(openBrace) ? sqlReplaceCommand.NewInput : string.Empty;
            }
            return sqlCommands.GetParsedString();
        }
        internal class SqlReplaceCommand
        {
            public string Command { get; set; }
            public string SqlResult { get; set; }
            public string PlaceHolder { get; set; }
            public string Text { get; set; }
            protected internal string NewInput { get; set; }
        }
    }
    internal static class SqlReplaceExtensions
    {
        public static string GetParsedString(this IEnumerable<MailingMergeString.SqlReplaceCommand> sqlCommands)
        {
            return sqlCommands.Aggregate("", (current, replaceCommand) => current + (replaceCommand.PlaceHolder + replaceCommand.Text));
        }
    }
