    public static User notepad(string np, User u){
      np = Console.ReadLine();
      u.notepad = np;
      return u;
    }
    static void Main(string[] args){
      ...
      xe = notepad(/*value of np*/, xe);
      ...
    }
