    for (int i =0; i < count; i++)  
    {        
       var property01 = t.GetProperty("MyPropertyOne");
       var propertyOneValue = property01.GetValue(myArry[i],null);
       Console.WriteLine(propertyOneValue);
    
       var property02 = t.GetProperty("MyPropertyTwo");
       var propertyTwoValue = property02 .GetValue(myArry[i],null);
       Console.WriteLine(propertyTwoValue);
      //And so on...
    }
