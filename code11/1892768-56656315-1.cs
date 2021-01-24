	while (!isValid && tries < maxTries)
	{
		isValid = true; // assume it's good until proven otherwise
		check = GetRoomBounds();
		for (int i = 0; i < rooms.Count; i++)
		{
			if (rooms[i].Walls.IntersectsWith(check.Walls)) // if it DOES intersect...
			{
				isValid = false; // .. then set valid to false.
				break;
			}
		}
		tries++;
	}
