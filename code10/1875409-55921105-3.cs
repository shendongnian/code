      float value;
      do {
        Console.Write("Enter the value, please: ");
        // Keep asking user
        value = parseFloat(Console.ReadLine());
      }
      while (float.IsNaN(value)); // while the input provided is invalid
