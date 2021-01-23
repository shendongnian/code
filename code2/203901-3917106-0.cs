    public static T DynamicFactorial<T>(T input) 
    { 
        dynamic num = input; 
        dynamic one = default(T);
        one++;
        dynamic res = one;  
        while (num > one)
        {
            res *= num;
            num--;
        }
        return res; 
    } 
