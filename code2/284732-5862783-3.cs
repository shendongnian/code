    LoadOperation loGetTickets = ticketClass.loadTickets();        
    loGetTickets.Completed += (s, args) =>  { 
      double ticketPrice;        
      // Set value of 'ticketPrice'
      ticketPrice = ...
      // Use the value of the variable
      Console.WriteLine(ticketPrice); // (*)
    };
