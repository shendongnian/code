    double ticketPrice;        
    LoadOperation loGetTickets = ticketClass.loadTickets();        
    loGetTickets.Completed += (s, args) =>  { 
      // Set value of 'ticketPrice'
      ticketPrice = ...
    };
    // Use the value of the variable
    Console.WriteLine(ticketPrice); // (*)
