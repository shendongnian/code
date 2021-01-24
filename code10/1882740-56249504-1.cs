    public static void DrawShape(int maxStars)
    {
        int lineLength = maxStars * 2 + 2;
        for (int row = 0; row < lineLength - 1; row++)
        {
            int starCount = maxStars - row;
            if (starCount == 0 || starCount == -1) continue;  // This is the hackey line
            if (starCount < 0) starCount *= -1;
            int spaceCount = lineLength - starCount * 2;
            string stars = new string('*', starCount);
            string spaces = new string(' ', spaceCount);
            Console.WriteLine(stars + spaces + stars);
        }
    }
