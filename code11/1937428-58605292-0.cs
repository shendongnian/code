     public double PhotoPrice(int width, int height)
     {
         ...
        if (width == 8 && height == 10)
        {
           return price[0]; // or price[1];
        }
        return 0;
     }
