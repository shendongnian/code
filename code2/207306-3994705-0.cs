        public string FirstNonRepeatingChar(string inString)
        {
            var array = inString.ToCharArray();
            foreach (char distinctChar in array.Distinct())
            {
                if (array.Count(x => x == distinctChar) == 1)
                    return distinctChar.ToString();
            }
            return null; //none
        }
