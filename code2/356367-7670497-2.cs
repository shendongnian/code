        static private string GetFileName(string url)
        {
            // (/:d[^"]*\.csv)  this RegEx works in visual studio!
            Match match = Regex.Match(url, @"(/[0-9].*\.csv)");
            string key = null;
            // Here we check the Match instance.
            if (match.Success)
            {
                // Finally, we get the Group value and display it.
                key = match.Groups[1].Value;
            }
            key = key.Replace("/", "");
            return key;
        }
