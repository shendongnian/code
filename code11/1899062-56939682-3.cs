        static List listX = new List();
        static List listY = new List();
        static List listZ = new List();
        static void Test1()
        {
            var points = new List<MyPoint>
            {
                new MyPoint {Id = 0, X = 97.5, Y = 92.5, Z = -16.6666660308838},
                new MyPoint {Id = 1, X = 292.5, Y = 92.5, Z = -16.6666660308838},
                new MyPoint {Id = 2, X = 97.5, Y = 277.5, Z = -16.6666660308838},
                new MyPoint {Id = 3, X = 292.5, Y = 277.5, Z = -16.6666660308838},
                new MyPoint {Id = 4, X = 97.5, Y = 462.5, Z = -16.6666660308838},
                new MyPoint {Id = 5, X = 292.5, Y = 462.5, Z = -16.6666660308838},
                new MyPoint {Id = 6, X = 97.5, Y = 92.5, Z = -49.9999980926514},
                new MyPoint {Id = 7, X = 292.5, Y = 92.5, Z = -49.9999980926514},
                new MyPoint {Id = 8, X = 97.5, Y = 277.5, Z = -49.9999980926514},
                new MyPoint {Id = 9, X = 292.5, Y = 277.5, Z = -49.9999980926514},
                new MyPoint {Id = 10, X = 97.5, Y = 462.5, Z = -49.9999980926514},
                new MyPoint {Id = 11, X = 292.5, Y = 462.5, Z = -49.9999980926514},
                new MyPoint {Id = 12, X = 97.5, Y = 92.5, Z = -83.3333320617676},
                new MyPoint {Id = 13, X = 292.5, Y = 92.5, Z = -83.3333320617676},
                new MyPoint {Id = 14, X = 97.5, Y = 277.5, Z = -83.3333320617676},
                new MyPoint {Id = 15, X = 292.5, Y = 277.5, Z = -83.3333320617676},
                new MyPoint {Id = 16, X = 97.5, Y = 462.5, Z = -83.3333320617676},
                new MyPoint {Id = 17, X = 292.5, Y = 462.5, Z = -83.3333320617676}
            };
            listX.Clear();
            listY.Clear();
            listZ.Clear();
            foreach (var point in points)
            {
                if (!listX.Contains(point.X))
                {
                    listX.Add(point.X);
                }
                if (!listY.Contains(point.Y))
                {
                    listY.Add(point.Y);
                }
                if (!listZ.Contains(point.Z))
                {
                    listZ.Add(point.Z);
                }
            }
            var result = new { sizeX = listX.Count, sizeY = listY.Count, sizeZ = listZ.Count };
        }
