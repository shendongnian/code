            string Positions = string.Join(" ", str.Reverse().Take(str.Count() - 3).ToArray());
            string output = "";
            string[] splitStrings = Positions.Split(' ');
            for (int i = splitStrings.Length - 1; i > -1; i--)
            {
                output = output + splitStrings[i] + " ";
            }
            Console.WriteLine("Result: " + output); //Owner Business
