    public Bowler Parse(string inputLine)
    {
        // split the line of text into its individual pieces
        var lineSegments = inputLine.Split(',');
        // create a new Bowler using those values
        var result = new Bowler
        {
            Name = lineSegments[0],
            Id = lineSegments[1],
            SomeOtherBowlerProperty = lineSegments[2]
        }
        return result;
    }
