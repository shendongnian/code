        public readonly struct State
        {
            public State(int x, int y = 0)
            {
                X = x;
                Y = y;
            }
            public int X { get; }
            public int Y { get; }
        }
        public static void BipartiteMatch(int x, int n, bool[] seen, int[] matches, Func<int, int, bool> isMapped)
        {
            var stack = new Stack<State>(new[] {new State(x)});
            while (stack.TryPop(out var state))
            {
                for (var y = state.Y; y < n; y++)
                {
                    if (seen[y] || !isMapped(state.X, y)) continue;
                    seen[y] = true;
                    if (matches[y] >= 0)
                    {
                        stack.Push(new State(state.X, y));
                        stack.Push(new State(matches[y]));
                        break;
                    }
                    matches[y] = state.X;
                    while (stack.TryPop(out state))
                    {
                        matches[state.Y] = state.X;
                    }
                    break;
                }
            }
        }
