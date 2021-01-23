    public bool CheckEngineLight(ICar car)
        {
            if (car.EngineLight)
            {
                car.GetOilChange();
                return true;
            }
    
            return false;
        } 
