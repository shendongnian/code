    public static class Lanes
    { 
        private static readonly Dictionary<string, Lane> LanesDictionary = 
            new Dictionary<string, Lane>();
        public static Lane GetLane(Direction direction, int number)
        {
            var key = direction.ToString() + number;
            if (LanesDictionary.ContainsKey(key))
            {
                return LanesDictionary[key];
            }
            var lane = new Lane(direction, number);
            LanesDictionary.Add(key, lane);
            return lane;
        }
    }
