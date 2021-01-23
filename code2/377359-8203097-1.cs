     class Messages
     {
         private string myName;
         public void Hello()
         {
             Console.WriteLine("Hello and welcome.");
         }
         public void QuestionWhatIsYourName()
         {
            Console.WriteLine("What is your name?");
            myName = Console.ReadLine();            
         }
         public void QuestionSurname()
         {
             QuestionWhatIsYourName();
             Console.WriteLine(myname + " what is your surname?");
         } 
    }
