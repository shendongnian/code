    using (var conn = new OracleConnection(.......))
    using (var cmd = new OracleCommand(.......))
    {
      // . . . . .  CODE HERE ........   
      using (var adp = new OracleDataAdapter(....) // if you need to fill table
      {
          // fill table
      }
    }
    // NOTE: no need close/dispose (automatic with using). Transaction committed internally. 
    // If SP errors out, everything is rolled back. Wrap this into `Try/Catch(OracleException ex)`
