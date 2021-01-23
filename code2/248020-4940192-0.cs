        private static string DeleteLines(string input, int lines)
        {
            var result = input;
            for(var i = 0; i < lines; i++)
            {
                var idx = result.IndexOf('\n');
                if (idx < 0)
                {
                    // do what you want when there are less than the required lines
                    return string.Empty;
                }
                result = result.Substring(idx+1);
            }
            return result;
        }
