    private bool[] Get_CharacterArray(string text)
        {
            // Declare the length of the array, all set to false
            bool[] characters = new bool[text.Length];
    
            // Get the matching points
            List<Point> wordLocs = FindMatchingTerms(text);
            wordLocs.Sort(PointComparison);
    
            int position = 0;
            foreach (Point loc in wordLocs)
            {
                // We're only setting the array for matched points
                for (position = loc.X; position <= loc.Y; position++)
                {
                    characters[position] = true;
                }
            }
    
            // Return the array
            return characters;
        }
