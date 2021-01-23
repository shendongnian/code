            //Gets Upgrade information and upgrade Files from Upgrade Folder 
            string strRegex = @"^B(?<Base>[0-9]{4})_A(?<Active>[0-9]{4})_U(?<Upgrade>[0-9]{4}).txt$";
            RegexOptions myRegexOptions = RegexOptions.ExplicitCapture | RegexOptions.Compiled;
            Regex myRegex = new Regex(strRegex, myRegexOptions);
            DirectoryInfo di = new DirectoryInfo(g_strAppPath + "\\Update Files");
            FileInfo[] rgFiles = di.GetFiles("*.txt");
            foreach (FileInfo fi in rgFiles)
            {
                string name = fi.Name.ToString();
                Match matched = myRegex.Match(name);
                if (matched.Success)
                {
                    //do the inserts into the data table here
                    string baseFw = matched.Groups["Base"].Value;
                    string activeFw = matched.Groups["Active"].Value;
                    string upgradeFw = matched.Groups["Upgrade"].Value;
                }
            }
