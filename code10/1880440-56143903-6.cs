     public float Price
            {
                get
                {
                    return bPrice;
                }
    
                set
                {
                    if (value > 30)
                    {
                        bPrice = value - (value * 0.10);
                    } 
                    else
                    {
                        bPrice = value;
                    }
                }
            }
