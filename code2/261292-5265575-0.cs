    public class AgentPathfinder
    {
        class SolutionComparer : IComparer<Solution>
        {
            public int Compare(Solution x, Solution y)
            {
                return x.Cost.CompareTo(y.Cost);
            }
        }
        class Solution 
        {
            public List<FixedVector> Path { get; private set; }
            public FixedVector LastPosition { get { return Path[Path.Count - 1]; } }
            public Fixed32 Heuristic { get; set; }
            public Fixed32 Cost { get; set; }
            public Solution(FixedVector position, Fixed32 heuristic)
            {
                Path = new List<FixedVector>(2) { position };
                Heuristic = heuristic;
                Cost = Path.Count + heuristic;
            }
            public Solution(FixedVector position
                , Fixed32 heuristic
                , List<FixedVector> path)
            {
                Path = new List<FixedVector>(path) { position };
                Heuristic = heuristic;
                Cost = Path.Count + heuristic;
            }
        }
        // TODO: replace with pathable terrain data
        public Map Map { get; set; }
        public FixedVector Position { get; set; }
        public FixedVector Destination { get; set; }
        public List<FixedVector> Path { get; set; }
        public void Compute()
        {
            var visited = new bool[(int)Map.Size.Width, (int)Map.Size.Height];
            var pq = new PriorityQueue<Solution>(new SolutionComparer());
            var bestFit = new Solution(new FixedVector((int)(Position.X + 0.5)
                , (int)(Position.Y + 0.5))
                , (Destination - Position).Length
                );
            pq.Enqueue(bestFit);
            while (pq.Count > 0)
            {
                var path = pq.Dequeue(); // optimal, thus far
                if (path.Heuristic < bestFit.Heuristic) // best approximation?
                {
                    // if we starve all other paths we
                    // fallback to this, which should be the best
                    // approximation for reaching the goal
                    bestFit = path;
                }
                for (int i = 0; i < FixedVector.Adjacent8.Length; i++)
                {
                    var u = path.LastPosition + FixedVector.Adjacent8[i];
                    if (Map.Size.Contains(u))
                    {
                        if (Map.IsPathable(u))
                        {
                            if (!visited[(int)u.X, (int)u.Y])
                            {
                                // heuristic (straight-line distance to the goal)
                                var h = (Destination - u).Length; 
                                var solution = new Solution(u, h, path.Path);
                                if (h < 1)
                                {
                                    Path = solution.Path;
                                    return; // OK, done
                                }
                                else
                                {
                                    // keep looking
                                    pq.Enqueue(solution);
                                }
                                visited[(int)u.X, (int)u.Y] = true;
                            }
                        }
                    }
                }
            }
            Path = bestFit.Path;
        }
    }
