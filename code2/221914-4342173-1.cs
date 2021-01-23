    public string ReturnName(ref int position)
    {
         position = 1;
         return "Temp"
    }
    public string GetName()
    {
         int i =0;
         string name = ReturnName(ref i);
         // you will get name as Temp and i =1
    }
    // best use out parameter is the TryGetXXX patternn in various places like (int.TryParse,DateTime.TryParse)
     int i ;
     bool isValid = int.TryParse("123s",out i);
