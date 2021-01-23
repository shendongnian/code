    class Program
    {
        static void Main(string[] args)
        {
            List<List<Point>> Positions; // TODO: Fill with all possible starting positions
            var PossibleRoutes = WalkGraph(Positions, 5);
        }
        static List<List<Point>> WalkGraph(List<List<Point>> RoutesList, int DesiredLength)
        {
            List<List<Point>> Result = new List<List<Point>>();
            foreach (var Route in RoutesList)
            {
                if (Route.Count < DesiredLength)
                {
                    // Extend the route (produces a list of routes) and recurse
                    Result.AddRange(WalkGraph(ExtendRoute(Route), DesiredLength));
                }
                else
                {
                    Result.Add(Route);
                }
            }
            return Result;
        }
        static List<List<Point>> ExtendRoute(List<Point> Route)
        {
            List<List<Point>> NextMoveRoutes = new List<List<Point>>();
            // Itterate through each possible move
            foreach (var NextMove in PossibleMoves(Route.Last()))
            {
                // Create a copy of the route, and add this possible move to it.
                List<Point> NextMoveRoot = new List<Point>(Route);
                NextMoveRoot.Add(NextMove);
            }
            return NextMoveRoutes;
        }
        static List<Point> PossibleMoves(Point P)
        {
            // TODO Generate a list of possible places to move to
        }
    }
