    //changed it to void cause you arent returning any value
    //removed string np argument because you were not using its value (you were overriding it before you use it)
    public static void notepad(User u){
      string np = Console.ReadLine();
      u.notepad = np;
    }
