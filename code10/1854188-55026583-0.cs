        string AddStars(string input)
        {
            var words = input.Split(' ');
            var output = "";
            foreach (var word in words)
            {
                output += word;
                if (!word.ToCharArray().ToList().All(char.IsLetter))
                    output += "*";
                output += " ";
            }
            return output.TrimEnd();
        }
