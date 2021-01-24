        const int Bounds = 1000;
        static bool RemovedOverlappingRects(Rectangle[] rects)
        {
            for (int pos = 0; pos < rects.Length; ++pos)
            {
                for (int check = pos +1; check < rects.Length; ++check)
                {
                    var r1 = rects[pos];
                    var r2 = rects[check];
                    if (r1.IntersectsWith(r2))
                    {
                        r2.Y = Rng.Next(1, Bounds);
                        rects[check] = r2;
                        Console.WriteLine($"{pos} overlaps with {check}");
                        return true;
                    }
                }
            }
            return false;
        }
