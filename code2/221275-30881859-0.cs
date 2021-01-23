    class Person
    {
      public string AnswerGreeting()
      {
         return "Hi, I'm doing well. And you?";
      }
    }
    
    class Employee : Person
    {
       new public string AnswerGreeting()
       {
          "Hi, and welcome to our resort.";
       }
    }
