       static void Main()
       {
           char entry = '0';
 
 
           //instantiate one new Accounts object
           Accounts accounts = new Accounts();
 
           //call class methods to fill Accounts
           accounts.fillAccounts();
 
           //menu with input options
           bool Exit = false;
           while (!Exit)   
           {
           while (entry != 'x' && entry != 'X')
           {
 
 
               Console.WriteLine("*****************************************");
               Console.WriteLine("enter an a or A to search account numbers");
               Console.WriteLine("enter a b or B to average the accounts");
               Console.WriteLine("enter an x or X to exit program");
               Console.WriteLine("*****************************************");
 
 
              entry = Convert.ToChar(Console.ReadLine());
 
                   switch (entry)  //set switch
                   {
                       case 'a':
                       case 'A':
                           accounts.searchAccounts();//calls search accounts method
                           break;
                       case 'b':
                       case 'B':
                           accounts.averageAccounts();//calls average accounts method
                           break;
                       case 'x':
                       case 'X':
                           (Exit) = true;
                           break;
                       default:
							Console.WriteLine("That is not a valid input");
                           break;
                   }
               }  
           }    
       } 
   } 
} 
