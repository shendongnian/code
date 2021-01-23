            var possibleChars = new List<char>();
            for(var c='a';c<='z';c++)
            {
                possibleChars.Add(c);
            }
            for (var c = 'A'; c <= 'Z'; c++)
            {
                possibleChars.Add(c);
            }
            for (var c = '0'; c <= '9'; c++)
            {
                possibleChars.Add(c);
            }
            var r = new Random();
            var randomChar = possibleChars[r.Next(possibleChars.Count)];
