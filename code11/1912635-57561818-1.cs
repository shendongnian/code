   static void Main(string[] args)
        {
            int[] points = new int[] { 1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10};
            foreach (string s in args)
            {
                int sum = 0;
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                    {
                        sum += points[Char.ToLower(c) - 'a'];
                    }
                }
                Console.WriteLine("Points for {0} = {1}", s, sum);
            }
        }
Explanation:
Each character is worth a certain point value.
Each character is  in the range of 'a' to 'z'
Make an array of the preset point values per character.
De-reference the point value by using the character to index into the array of values.  Accumulate sum.
Eg: `points[0]` is the point for `a`
`points[3]` is the point value for `d`
Good luck.
