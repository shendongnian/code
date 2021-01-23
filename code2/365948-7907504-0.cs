    public void RemoveTestClass(int intValue) 
    { 
         var itemToRemove = MyList.FirstOrDefault(item => item.InValue == intValue);
         if (itemToRemove != null)
         {
             MyList.Remove(itemToRemove);
         }
    }     
