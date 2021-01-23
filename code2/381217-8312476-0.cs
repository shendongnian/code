    public void ToUpload(Beer beer, int dl)
    {
        int d = 0;
        if(beers[beer] != null)
            d = beers[beer];
        beers[beer] = d + dl;
    }
