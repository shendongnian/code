    private void Getnext()
    {
        
        if (counter < (loadedHouses.Count - 1))
        {
            counter++;
            GetHouse();
        }
    }
