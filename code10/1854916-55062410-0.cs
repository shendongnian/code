    class InputConverter
    {
      static Func<SalesOrder, bool> ToWherePredicate(string paramName, string paramValue)
      {
        switch (paramName)
        {
          case "Id:"
            int value = Int32.Parse(paramValue);
            return salesOrder => salesOrder.Id == value;
            break;
          case "OrderDate":
            DateTime value = DateTime.Parse(paramValue);
            return salesOrder => salesOrder.OrderDate == value;
            break;
          case "CustomerId":
            int value = Int32.Parse(paramValue);
            return salesOrder => salesOrder.CustomerId == value;
            break;
          case ...
          default:
            // Other string values are not supported
            throw new NotSupportedException(...);
        }
      }
    }
