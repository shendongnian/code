    string[] quizzes = new string[]
    {
        "Do you like ketchup? (yes/no)",
        "Do you like bread? (yes/no)",
        "Do you like to read? (yes/no)",
        "Do you like soda? (yes/no)"
    }
    
    int truecount = 0;
    foreach(var quiz in quizzes)
    {
        Console.WriteLine (quiz);
        if(Console.ReadLine().ToLower().Contains("yes")
            truecount++;
    }
    
    if(truecount > quizzes.Length / 2) // here it is your choice to use > or >= or even more cases like if(truecount == quizzes.Length) you love eggs else if ....
    {
      Console.WriteLine ("You probably like eggs");
    }
    else
    {
      Console.WriteLine ("I don't think you like eggs");
    }
