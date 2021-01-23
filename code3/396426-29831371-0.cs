     private int CountDistinct2DPoints(double[][] data)
        {
            Dictionary<Tuple<double, double>, int> pointsMap = new Dictionary<Tuple<double, double>, int>();
            for(int i = 0; i < data.Length; i++)
            {
                if (!pointsMap.ContainsKey(Tuple.Create(data[i][0], data[i][1])))
                {
                    pointsMap.Add(Tuple.Create(data[i][0], data[i][1]), 1);
                }
                else
                {
                    pointsMap[Tuple.Create(data[i][0], data[i][1])]++;
                }
            }
            return pointsMap.Keys.Count;
        }
