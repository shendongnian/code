    {
      // Create an object
      StringBuilder b = new StringBuilder();
      b.Append("asdf");
      // Here is the last use of the object:
      string x = b.ToString();
      // From this point the object can be collected whenever the GC feels like it
      // If you assign a null reference to the variable here is irrelevant
      b = null;
    }
