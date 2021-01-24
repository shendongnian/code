    List<Plek> EmptyList()
        {
            List<Place> Pair = new List<Place>();
            for (int p = 0; p < n; p++)
            {
                for (int q = 0; q < n; q++)
                {
                    if (Field[p, q] == 0)
                    {
                        Place pair = new Place(p, q);
                        Pair.Add(pair);
                    }
                }
            }
            return Pair;
        }
