          Console.WriteLine(theList.Count); // valid
          Console.WriteLine(theList[0]); // valid, prints default ToString
    
          Console.WriteLine(theList[0].num); // invalid! What's the point?
    
    }
    
    var list = new[] { new { str = "hi", num = 5, time = DateTime.Now } }.ToList();
    // valid due to type inference, but see comments above
    DoSomethingGenerically(list); 
