        private void loadArgs()
        {
            const string namedArgsPattern = "^(/|-)(?<name>\\w+)(?:\\:(?<value>.+)$|\\:$|$)";
            System.Text.RegularExpressions.Regex argRegEx = new System.Text.RegularExpressions.Regex(namedArgsPattern, System.Text.RegularExpressions.RegexOptions.Compiled);
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                System.Text.RegularExpressions.Match namedArg = argRegEx.Match(arg);
                if (namedArg.Success)
                {
                    switch (namedArg.Groups["name"].ToString().ToLower())
                    {
                        case "myArg1":
                            myVariable1 = namedArg.Groups["value"].ToString();
                            break;
                        case "myArg2":
                            myVariable2 = namedArg.Groups["value"].ToString();
                            break;
                        case "debug":
                            debugEnabled = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
