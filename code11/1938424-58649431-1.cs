        static bool IsPalindrome(string inputString)
        {
            var characters = inputString.ToCharArray();
            var stringLength = characters.Length;
            for (int i = 0; i < characters.Length/2; i++)
            {
                if (characters[i].Equals(characters[stringLength - 1 - i]))
                    continue;
                else
                    return false;
            }
            return true;
        }
Usage
            var result = IsPalindrome("asdffdsa");
