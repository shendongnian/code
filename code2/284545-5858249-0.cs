        object[,] rng = (object[,])range.Value;
        for (int row = rng.GetLowerBound(0); row <= rng.GetUpperBound(0); row++)
        {
            for (int day = rng.GetLowerBound(1); day <= rng.GetUpperBound(1); day++)
            {
                string dayName = rng[row,day] as string;
            }
        }
