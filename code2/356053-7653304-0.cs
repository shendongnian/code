    public double GetCost(int tot)
    {
        double cost = 0;
        while(tot > 0) {
            cost += tot >= 11 
                    ? list[11] 
                    : list[tot];
            tot -= tot % 11;
        }
        return cost;
    }      
