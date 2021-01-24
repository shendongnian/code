    Change the User Class to create a new HashSet of Boards something like:
   
    public User() 
    {
         Boards = new HashSet<Board>();
    }
    public User AddBoard(Board board, User user)
    {
        BulletinContext _context = new BulletinContext();
        User _user = _context.Users.Find(user.ID);
        _user.Boards.Add(board);
        return null;
    }
