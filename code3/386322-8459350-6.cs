    bool foundValidOP = false;
    foreach (string operation in operations) 
    {
        if (firstInput.Equals(operation, StringComparison.InvariantCultureIgnoreCase))
        {
            foundValidOP = true;
            break;
        }
    }
    if (foundValidOP)
    {
      Console.WriteLine("Valid operation: {0}", firstInput);
    }
    else
    {
      Console.WriteLine("Invalid operation: {0}", firstInput);
    }
