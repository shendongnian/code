       List<List<Point>> GetGroupedPoints(List<Point> points)
       {
            var lists = new List<List<Point>>();
            Point cur = null;
            List<Point> curList;
            foreach (var p in points)
            {
                if (cur == null || p != cur)
                {
                    curList = new List<Point>();
                    lists.Add(curList);
                }
                curList.Add(p);
            }
            return lists;
        }
