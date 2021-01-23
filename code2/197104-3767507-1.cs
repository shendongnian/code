      int menuchoice  = 0;  
            while (menuchoice != 7)  
            {  
      
                Console.WriteLine("MENU");  
                Console.WriteLine("Please enter the number that you want to do:");  
                Console.WriteLine("1. Do thing A");  
                Console.WriteLine("2. Do thing B");  
                Console.WriteLine("3. Do thing C");  
                Console.WriteLine("4. Do thing D");  
                Console.WriteLine("5. Do thing E");  
                Console.WriteLine("6. Do thing F");  
                Console.WriteLine("7. Exit");  
      
                menuchoice = int.Parse(Console.ReadLine());  
      
                switch (menuchoice)  
                {  
                    case 1:  
                        Console.WriteLine("Thing A has been done");   
                        break;  
                    case 2:  
                        Console.WriteLine("Thing B has been done");  
                        break;  
                    case 3:  
                        Console.WriteLine("Thing C has been done");  
                        break;  
                    case 4:  
                        Console.WriteLine("Thing D has been done");  
                        break;  
                    case 5:  
                        Console.WriteLine("Thing E has been done");  
                        break;  
                    case 6:  
                        Console.WriteLine("Thing F has been done");  
                        break;  
                    case 7:  
                        break;  //edit
                    default:  
                        Console.WriteLine("Sorry, invalid selection");  
                        break;  
                }  
