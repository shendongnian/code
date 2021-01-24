    else 
    {
        int speedChange = 0;
        if (_clickDestination.Y == Position.Y)
            speedChange = _clickDestionation.X.CompareTo(Position.X) * (int)Speed;
        else
        {
          if (_clickWalkStairsX != Position.X)
            speedChange = (int)Speed;
          else if (_clickDestination.X < Position.X)
            speedChange = -(int)Speed;
        }
    }
