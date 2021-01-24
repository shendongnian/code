    bool isUserNameValid = false;
    string inputUsername = "";
    do
    {
      Console.WriteLine("Enter Username");
      inputUsername = Console.ReadLine();
      for ( int i = 0; i < username.Length; i++ )
        if ( username[i] == inputUsername )
        {
          isUserNameValid = true;
          break;
        }
      if ( !isUserNameValid )
        Console.WriteLine("Incorrect Username, Try again");
    }
    while ( !isUserNameValid );
    bool isPasswordValid = false;
    int inputPassword = 0;
    do
    {
      Console.WriteLine("Enter Password");
      int.TryParse(Console.ReadLine(), out inputPassword);
      for ( int i = 0; i < password.Length; i++ )
        if ( password[i] == inputPassword )
        {
          isPasswordValid = true;
          break;
        }
      if ( !isPasswordValid )
        Console.WriteLine("Incorrect Password, Try again");
    }
    while ( !isPasswordValid );
