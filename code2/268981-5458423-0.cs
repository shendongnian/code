    private readonly Game _game;//doesn't HAVE to be readonly, but can simplify things if it is
    public Checkers(Game game)
    {
      if(game == null)
        throw new ArgumentNullException();
      _game = game;
      InitializeComponent();
    }
