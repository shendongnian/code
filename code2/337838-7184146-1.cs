        public bool ContainsGroup(string file)
        {
            using (var reader = new StreamReader(file))
            {
                var hasAction = false;
                var hasInput = false;
                var hasResult = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!hasAction)
                    {
                        if (line.StartsWith("ACTION:"))
                            hasAction = true;
                    }
                    else if (!hasInput)
                    {
                        if (line.StartsWith("INPUT:"))
                            hasInput = true;
                    }
                    else if (!hasResult)
                    {
                        if (line.StartsWith("RESULT:"))
                            hasResult = true;
                    }
                    if (hasAction && hasInput && hasResult)
                        return true;
                }
                return false;
            }
        }
