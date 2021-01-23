            List<Point> list = new List<Point>();
            list.Add(new Point(10, 10));
            list.Add(new Point(15, 10));
            list.Add(new Point(20, 10));
            list.Add(new Point(25, 15));
            list.Add(new Point(30, 15));
            var minX = (from p in list
                        where (p.Y.Equals(10))
                        select p.X).Min();
            var maxX = (from p in list
                        where (p.Y.Equals(10))
                        select p.X).Max();
            Console.WriteLine(minX.ToString());
            Console.WriteLine(maxX.ToString());
            Console.ReadLine();
