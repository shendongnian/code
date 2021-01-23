     List<string> l = new List<string>(lines);
            List<string> matchingLines = l.FindAll(x => x.Contains("Month of Birth" + month));
            string output = "";
            foreach (string line in matchingLines)
            {
                output += line + Environment.NewLine;
            }
            output.TrimEnd(Environment.NewLine);
            label7.Text = output; 
