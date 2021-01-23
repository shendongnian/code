    DataTable dTable = null;
    SQLiteConnection connection = null;
    SQLiteCommand command = null;
    SQLiteDataReader dReader = null;
    try
    {
      // non-DB code
      // DB code
    }
    catch (SQLiteException sqle)
    {
      // Handle DB exception
    }
    catch (IndexOutOfRangeException ie)
    {
      // If you think there might be a problem with index range in the loop, for example
    }
    catch (Exception ex)
    {
      // If you want to catch any exception that the previous catches don't catch (that is, if you want to handle other exceptions, rather than let them bubble up to the method caller)
    }
    finally
    {
      // I recommend doing some null-checking here, otherwise you risk a NullReferenceException.  There's nothing quite like throwing an exception from within a finally block for fun debugging.
      connection.Dispose();
      command.Dispose();
      dReader.Dispose();
      dTable.Dispose();
    }
    return null;
