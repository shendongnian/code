    public User AddBoard(Board board, User user)
        {
            BulletinContext _context = new BulletinContext();
            User _user = _context.Users.Find(user.ID);
            Board _board = _context.Boards.Find(board.ID);
            _user.Boards.Add(_board);
            _context.SaveChanges();
            return null;
        }
