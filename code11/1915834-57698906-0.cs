    public static string GetRandomLine(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var lineNumber = _rand.Next(0, lines.Length - 1);
            var blankBefore = lineNumber;
            var blankAfter = lineNumber + 1;
            string reply = "";
            while (lines[blankBefore].Length > 0)
            {
                blankBefore--;
            }
            while (lines[blankAfter].Length != 0)
            {
                blankAfter++;
            }
            
            for ( int i = blankBefore + 1; blankBefore < blankAfter; blankBefore++)
            {
                reply += lines[i];
            }
            return reply;
        }
