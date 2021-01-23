    var ordinal = rdr.GetOrdinal("timeOut");
    if(rdr.IsDBNull(ordinal)) {
      queryResult.Egresstime = "Logged in";
    } else {
      queryResult.Egresstime = rdr.GetString(ordinal);
    }//if
