    using System;
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
                IEnumerable<IEnumerable<Point>> Positions = from X in Enumerable.Range(0, GridSize)
                                                            from Y in Enumerable.Range(0, GridSize)
                                                            select new List<Point>() { new Point(X, Y) } as IEnumerable<Point>;
                var PossibleRoutes = WalkGraph(Positions, 100);
                foreach (var Route in PossibleRoutes)
                {
                    Console.WriteLine(Route.Select(P => P.ToString()).Aggregate((curr, next) => curr + " " + next));
                    //Thread.Sleep(500); // Uncomment this to slow things down so you can read them!
                }
                Console.ReadKey();
            }
            static IEnumerable<IEnumerable<Point>> WalkGraph(IEnumerable<IEnumerable<Point>> RoutesList, int DesiredLength)
            {
                foreach (var Route in RoutesList)
                {
                    if (Route.Count() < DesiredLength)
                    {
                        // Extend the route (produces a list of routes) and recurse
                        foreach (var ExtendedRoute in WalkGraph(ExtendRoute(Route), DesiredLength))
                            yield return ExtendedRoute;
                    }
                    else
                    {
                        //Result.Add(Route);
                        yield return Route;
                    }
                }
            }
            static IEnumerable<IEnumerable<Point>> ExtendRoute(IEnumerable<Point> Route)
            {
                // Itterate through each possible move
                foreach (var NextMove in PossibleMoves(Route.Last()))
                {
                    // Create a copy of the route, and add this possible move to it.
                    List<Point> NextMoveRoute = new List<Point>(Route);
                    NextMoveRoute.Add(NextMove);
                    yield return NextMoveRoute;
                }
            }
            static IEnumerable<Point> PossibleMoves(Point P)
            {
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
                return Result as IEnumerable<Point>;
            }
        }
    }
