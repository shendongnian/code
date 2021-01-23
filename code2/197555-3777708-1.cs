            //Regex example
            string pattern = @"(I|am|Steven)(?<=\b\w+\b)";
            string data2 = "I am Steven";
            MatchCollection mx = Regex.Matches(data2, pattern);
            foreach (Match m in mx)
            {
                Console.WriteLine("{0} {1} {2}", m.Value, m.Index, m.Length);
            }
            string negativePattern = @"^.*(?!King).*$";
            MatchCollection mx2 = Regex.Matches(data2, negativePattern);
            if (mx2.Count != 1)
                Console.WriteLine("Contains a negative match.");
