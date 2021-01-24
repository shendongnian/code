    if (PlaceInQue <= 1)
    {
        result = "Very soon!";
    }
    else if (PlaceInQue < 5)
    {
        result = "From 0 to 1 weeks.";
    }
    else if (PlaceInQue < 11)
    {
        result = "From 1 to 2 weeks.";
    }
	else if 
	{
		for (int n = 11; n <= max; n += 5)
		{
			if (PlaceInQue >= n && PlaceInQue < n + 5)
			{
				int weeks = n / 5;
				result = $"From {weeks} to {(weeks + 1)} weeks.";
				break;
			}
		}
	}
