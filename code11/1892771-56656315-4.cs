	while (!isValid && tries < maxTries)
	{
		check = GetRoomBounds();
		for (int i = 0; i < rooms.Count; i++)
		{
			if (!rooms[i].Walls.IntersectsWith(check.Walls))
			{
				isValid = true;
				break;
			}
		}
		tries++;
	}
