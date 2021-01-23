            string s = "hello world; some random text; foo;";
            Regex r = new Regex(".*?;{1}");
            var match = r.Match(s);
            while(match.Success)
            {
                Console.WriteLine(match.Value.ToString());
                match = r.Match(s, match.Index + match.Length); // move match index to avoid getting the same match
            }
