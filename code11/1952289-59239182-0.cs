    int userInput = Convert.ToInt32(Console.ReadLine());
    bool exists= false;
                foreach (KeyValuePair<int,Library> lib in dictionary)
                {
                    if (userInput == lib.Key)
                    {
                        Console.WriteLine("You chose book = {0}",lib.Value.bookName);
                        exists = true;
                    }
                }
                if(!exists){
                      Console.WriteLine("Wrong Input");
                }
