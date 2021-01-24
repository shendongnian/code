    TheTypeOfParameter parameterFound = null;
    TheTypeOfParameter parameterHavingDateNotNull = null;
    TheTypeOfParameter parameterHavingDateNull = null;
    bool foundDateNull = false;
    bool foundDateNotNull = false;
    foreach ( var item in query )
    {
      if ( !foundDateNull && item.EndDate == null )
      {
        parameterHavingDateNull = item;
        foundDateNull = true;
      }
      else
      if ( !foundDateNotNull && item.EndDate > givenDate )
      {
        foundDateNotNull = true;
      }
      if ( !foundDateNotNull )
        parameterHavingDateNotNull = item;
      if ( foundDateNotNull || foundDateNull )
        break;
    }
    parameterFound = parameterHavingDateNotNull != null
                   ? parameterHavingDateNotNull
                   : parameterHavingDateNull;
