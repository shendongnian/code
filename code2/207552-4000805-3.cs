    foreach(object item in list)
    {
        // Trying to unboxing into the wrong type here...
        // This will raise an exception at runtime, but compile fine!
        double value = (double)item;
        Console.WriteLine(value);
    }
