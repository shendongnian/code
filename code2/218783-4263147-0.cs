          static void Main(string[] args)
        {
            List<string> inputList = new List<string>();
            inputList.Add("<input type=\"radio\" name=\"eq_9\" id=\"eq_9_2\"  onclick=\"nextStepID_load(this);\" value=\"Installer.\" title=\"912\" /><label for=\"eq_9_2\">Installer</label> <br />");
            inputList.Add("<input type=\"radio\" name=\"eq_10\" id=\"eq_9_3\"  onclick=\"nextStepID_load(this);\" value=\"Installer1.\" title=\"913\" /><label for=\"eq_9_3\">InstallerA</label> <br />");
            inputList.Add("<input type=\"radio\" name=\"eq_11\" id=\"eq_9_4\"  onclick=\"nextStepID_load(this);\" value=\"Installer2.\" title=\"914\" /><label for=\"eq_9_4\">InstallerB</label> <br />");
            inputList.Add("<input type=\"radio\" name=\"eq_12\" id=\"eq_9_5\"  onclick=\"nextStepID_load(this);\" value=\"Installer3.\" title=\"915\" /><label for=\"eq_9_5\">InstallerC</label> <br />");
            inputList.Add("<input type=\"radio\" name=\"eq_13\" id=\"eq_9_6\"  onclick=\"nextStepID_load(this);\" value=\"Installer4.\" title=\"916\" /><label for=\"eq_9_6\">InstallerD</label> <br />");
            string output = string.Empty;
            string target = "<button type=\"button\" name=\"{0}\" id=\"{1}\" onclick=\"nextStepID_load('{2}');\">{3}</button><br />";
            foreach (string input in inputList)
            {
                string name = GetValue(@"(?<Value>name=[\S]+)", input);
                string id = GetValue(@"(?<Value>id=[\S]+)", input);
                string title = GetValue(@"(?<Value>title=[\S]+)", input);
                string value = GetValue(@"(?<Value>value=[\S]+)", input);
                output = string.Format(target, name, id, title, value);
                System.Diagnostics.Debug.WriteLine(output);
            }
            
        }
        private static string GetValue(string pattern, string input)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            return match.ToString().Split('=').Last().Replace("\"", string.Empty);
        }
