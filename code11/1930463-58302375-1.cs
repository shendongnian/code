    double total = 0;
    int passover = 4;
    int input = 0;
    do
    {
      passover++;
      Console.Write("Enter your number: ");
      int.TryParse(Console.ReadLine(), out input);
      if ( passover != 5 ) continue;
      passover = 1;
      total = total + input;
    }
    while ( input != 0 );
    Console.WriteLine("The sum of every fifth numbers is: {0}", total);
    Console.ReadKey();
