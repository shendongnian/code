            string input = "http://example.com/TIGS/SIM/Lists/Team Discussion/DispForm.aspx?ID=1779";
            string given = "http://example.com/TIGS/SIM/Lists";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(given + @"\/(.+)\/");
            System.Text.RegularExpressions.Match match = regex.Match(input);
            Console.WriteLine(match.Groups[1]); // Team Discussion
