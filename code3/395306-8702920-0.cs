    public void myMethod(int value)
    {
        List<int> intList = new List<int>();
        List<Drinking> drinkingList= (from d in myEntities.Drinking
                              select d).ToList();
        foreach (var d in drinkingList)
        {
           if (d.Drinking2Reference.EntityKey != null)
           {
              if(d.idCategory == value)
                 intList.Add(value);
              else {
                 foreach(int number in intList) {
                    if(number == d.idParentCategory)
                       intList.Add(d.idCategory);
                 }
              }
              
           }
        }
        //Print numbers    
    }
