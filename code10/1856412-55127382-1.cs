    int fahrenheit;
    while (true)
    {
       try
       {
            fahrenheit = Convert.ToInt32(Console.ReadLine());
            break;
       }
       catch (FormatException)
       {
          continue;
       }
    }
    celsius = FahrenheitToCelsius(fahrenheit);
