    class Account
    {
        public IEnumerable<User> Users { get; set; }
        public User SingleUser { get; set; }
        static void Query()
        {
            IQueryable<Account> accounts = new Account[0].AsQueryable();
            Expression<Func<User, bool>> userExpression = x => x.Selected;
            Expression<Func<Account, bool>> accountAndUsersExpression =
                x => x.Users.AsQueryable().Where(userExpression).Any();
            var resultWithUsers = accounts.Where(accountAndUsersExpression);
            Expression<Func<Account, bool>> accountAndSingleUserExpression =
                x => new[] { x.SingleUser }.AsQueryable().Where(userExpression).Any();
            var resultWithSingleUser = accounts.Where(accountAndSingleUserExpression);
        }
    }
    class User
    {
        public bool Selected { get; set; }
    }
