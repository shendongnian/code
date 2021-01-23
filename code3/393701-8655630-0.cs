            string pattern = @"[0-9]{1}[a-z]{1}";            
            var regexp = new System.Text.RegularExpressions.Regex(pattern);
            var matches = regexp.Matches("2x3y5z");            
            foreach (var match in matches)
            {
                Debug.WriteLine(match);
            }
