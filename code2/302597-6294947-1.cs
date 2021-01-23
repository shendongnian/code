    class Exchange
    {
      public TelephoneLine MakeCall (Person from, Person to)
      {
        // check that 'to' can receive call first!
        return new TelephoneLine (from, to);
      }
    };
    class Person
    {
      public void MakeCall (Person receiver, string message)
      {
         TelephoneLine line = the_exchange.MakeCall (this, receiver);
         if (line != null)
         {
           line.Send (this, message);
         }
         // else, receiver not listening!
      }
    }
