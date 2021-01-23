    public bool IsInTheRange(int parameter)
    {
        int rangeMin = 0x0A;
        int rangeMax = 0x0F;
        return (parameter >= rangeMin) && (parameter <= rangeMax);
    }
