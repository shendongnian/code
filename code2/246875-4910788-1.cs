    public List<Binding> Binds;
    // Later...
    Binds.Add( new Binding(ConsoleKey.L, () => 
       {
           // Do something when L is pressed
       });
    Binds.Add( new Binding(ConsoleKey.Q, () => 
       {
           // Do something when Q is pressed
       });
