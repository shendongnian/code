    string firstname;
    string lastname;
    string userAge;
    
    //takes user input 
    Console.Write("please enter your first name - "); 
    
    //stores user input 
    firstname = Console.ReadLine(); 
    
    Console.Write("please enter your last name - ");
    
    lastname = Console.ReadLine();
    
    Console.Write("please enter your age - ");
    
    userAge = Console.ReadLine();  
    
    //prints user input to screen the 0 is the position
    Console.WriteLine("Your name is {0} {1} and your age is {2}.", 
            firstname, lastname, userAge); 
    
    //pauses the program for 1000 mlseconds so you can see what the result is 
    Thread.Sleep(2000); 
