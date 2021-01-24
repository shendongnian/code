    string choice = Console.ReadLine();
    int choiceValue; 
      
      bool success = Int32.TryParse(choice , out choiceValue);
    
      if(success){
        // it was a number then do an operation
      }
      else{
       // was not a number do other operation
    }
