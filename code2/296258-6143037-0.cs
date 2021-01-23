        public string FormatPhone(string input)
        {
            List<char> chars = new List<char>();
            if (input.Length < 9) throw new ArgumentException("Not long enough!");
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (Char.IsNumber(input[i])) chars.Add(input[i]);
                switch (chars.Count)
                {
                    case 4:
                        chars.Add('-');
                        break;
                    case 8:
                        chars.Add(' ');
                        chars.Add(')');
                        break;
                    case 13:
                        i = 0;
                        break;
                }
            }
            chars.Add('(');
            chars.Reverse();
            return new string(chars.ToArray());
        }
