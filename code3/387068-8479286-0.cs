    for (int playerID = 1; playerID <= participants; playerID++)
            {
                checkA = Check4forsequenceof4(matrix); //method A
                if (checkA != 0)
                     Console.WriteLine(p + "completed check A");
                else
                     continue;
                
                if (checkB != 0)
                   Console.WriteLine(p + "completed check B");
                 else
                     continue;
                
                if (checkC != 0)
                   Console.WriteLine(p + "completed check C");
                 else
                     continue;
               
            }
