    public enum ModelType
    {
        Ferrari = 0,
        AstonMartin = 1
    }
    
    public int GetMaxSpeed( Car car )
    {
        switch( car.Model )
        {
            case Ferrari:
               return 300;
            case AstonMartin:
               return 250;
            default:
               return 100;
        }
    }
