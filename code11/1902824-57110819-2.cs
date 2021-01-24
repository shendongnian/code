    while (true)
    {
          string celsius = Console.ReadLine();    
          if (string.IsNullOrWhiteSpace(celsius))    
                break;    
           if(float.TryParse(celsius, out float convcel))    
           {
               float fahren = (float)(1.8 * convcel) + 32;    
               Console.WriteLine(fahren);    
           }
        } 
