    using (var conn = new OracleConnection(.......))
    using (var cmd = new OracleCommand(.......))
    {
      // . . . . .  CODE HERE ........   
      using (var adp = new OracleDataAdapter(....) // if you need to fill table
      {
          // fill table
      }
    }
