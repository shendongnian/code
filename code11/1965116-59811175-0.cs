    public User AddBoard(Board board, User user)
        {
            BulletinContext _context = new BulletinContext();
            User _user = _context.Users.Find(user.ID);
            _user.Boards.Add(board);
            _context.SaveChanges();
            return null;
        }
