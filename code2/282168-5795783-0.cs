    var op1 = new OracleParameter {
                                    ParameterName = "StudentId",
                                    Size = 6,
                                    OracleDbType = OracleDbType.Int32,
                                    Direction = System.Data.ParameterDirection.Input
                                    SourceColumn = "StudentId" // If that's what it's called in the DataTable
                                  };
    command.Parameters.Add(op1);
