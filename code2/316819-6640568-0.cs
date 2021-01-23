     int num;
     try
     {  
         num = int.Parse(str);
     }
     catch(Exception e)
     {
         Console.Writeline("Not a number!");
     }
