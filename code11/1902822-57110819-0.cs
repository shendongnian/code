    while (true)
    {
          string celsius = Console.ReadLine();    
           if (celsius == null)    
                break;    
           if(float.TryParse(celsius, out float convcel))    
           {
               float fahren = (float)(1.8 * convcel) + 32;    
               Console.WriteLine(fahren);    
           }
        } 
