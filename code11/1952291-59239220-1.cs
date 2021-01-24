    bool wrongInput = true;
    int userInput = Convert.ToInt32(Console.ReadLine());
    foreach (KeyValuePair<int,Library> lib in dictionary)
    {
         if (userInput == lib.Key)
         {
               Console.WriteLine($"You chose book = {lib.Value.bookName}");
               wrongInput = false;
               break; // exit early as there's no need to continue the iterating.
         }
    }
    if (wrongInput) Console.WriteLine("Wrong Input");
