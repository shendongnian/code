    ...
    var validName = false;
     while (!validName)
     {
        if(!Regex.Match(name, "^[A-Za-z ]+$")
          Console.WriteLine("Invalid name; try again");
        else
          validName = true;
     }
    ...
