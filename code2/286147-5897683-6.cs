    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static int GridSize = 5;
            static void Main(string[] args)
            {
                List<List<Point>> Positions = (from X in Enumerable.Range(0, GridSize)
                                               from Y in Enumerable.Range(0, GridSize)
                                               select new List<Point>() { new Point(X, Y) }).ToList();
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
                    NextMoveRoutes.Add(NextMoveRoot);
                }
                return NextMoveRoutes;
            }
            static List<Point> PossibleMoves(Point P)
            {
                // TODO Generate a list of possible places to move to
                List<Point> Result = new List<Point>();
                Result.Add(new Point(P.X + 1, P.Y + 2));
                Result.Add(new Point(P.X - 1, P.Y + 2));
                Result.Add(new Point(P.X + 1, P.Y - 2));
                Result.Add(new Point(P.X - 1, P.Y - 2));
                Result.Add(new Point(P.X + 2, P.Y + 1));
                Result.Add(new Point(P.X - 2, P.Y + 1));
                Result.Add(new Point(P.X + 2, P.Y - 1));
                Result.Add(new Point(P.X - 2, P.Y - 1));
                Result.RemoveAll(PossibleMove => PossibleMove.X < 0 || PossibleMove.X > GridSize ||
                                                 PossibleMove.Y < 0 || PossibleMove.Y > GridSize);
                return Result;
            }
        }
    }
