     Random rng = new Random();
     txtR500.Text = GenerateDigit(rng, 40, 65).ToString();
     static int GenerateDigit(Random rng, int min, int max)
        {
            // Assume there'd be more logic here really
            int i=rng.Next(min, max);
            for (int j = min; j < max; )
            {
                if ((i % 5 == 0) || (i % 5 == 5))
                {
                    return i;
                }
                else
                { i++; }
            }
            return 0;
        }
