    foreach(var flight in flightList)
    {
       try {
           var samples = GetRawGPSDataIntoAString();
           foreach(var line in samples)
           {
              var line = splitTheSampleIntoAListOfStrings();
              foreach(var sampleSection in line)
              {
                 try {
                     DoSomeStuff();
                 }
                 catch(Exception ex) {
                     log(ex);
                     throw; // <--- HERE, we didn't solve the problem
                            // so we let the exception reach the next catch
                 }
              }
           }
           catch (ContinuableException ex2) { /* ignore and keep trying */ }
       }
    }
