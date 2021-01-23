    int itemsCount = yourDictionary.Count;
    bool isLast = false;
    
    foreach(var item in yourDictionary)
    {
       itemsCount--;       
       isLast = itemsCount == 0; 
       
       if(isLast)
       {
         // this is the last item no matter the order of the dictionary        
       }
       else
      {
        //not the last item
      }
    }
