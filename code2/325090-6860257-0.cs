    gameGrid.DetectNeighbours2(gameGrid.planets.Last());
    //Flood fill algorithm to detect all connected planets
        internal void DetectNeighbours(Planet p)
        {
            try
            {
                if (p == null || p.deletable)
                    return;
                p.deletable = true;
                DetectNeighbours(GetTopNode(p));
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }
        internal Planet GetTopNode(Planet b)
        {
            foreach (Planet gridPlanet in planets)
            {
                if (gridPlanet .Y == b.Y - 50)
                    return gridPlanet ;       
            }
            return null;
        }
