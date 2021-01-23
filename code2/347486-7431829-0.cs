    public static bool TryGetInstance(int max, out Car instance)
    {
        instance = null;
        if(max > 50)
        {
            return false;
        }
        
        instance = new Car(max);
        return true;
    {
