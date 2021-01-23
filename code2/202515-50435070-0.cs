           Console.Write("Insert 5 numbers between 10 and 100\n");
            // tell the user what to do and make sure you insert "\n" at the
               end            
               
               int temp=0;
               int[] arrayOfNumbers = new int[5];
              
            for (int i = 0; i < arrayOfNumbers.Length; i++)
                {
          switch (i + 1)
                    {
                        case 1:
                            Console.Write("\nEnter First number: ");
                            
                            
                            break;
                        case 2:
                            Console.Write("\nEnter Second number: ");
                            
                            break;
                        case 3:
                            Console.Write("\nEnter Third number: ");
                         
                            break;
                        case 4:
                            Console.Write("\nEnter Fourth number: ");
                           
                            break;
                        case 5:
                            Console.Write("\nEnter Fifth number: ");
                            
                            
                            break;
                    } // end of switch
                        temp = Int32.Parse(Console.ReadLine()); // convert 
                        arrayOfNumbers[i] = temp; // filling the array
                        }// end of for loop 
