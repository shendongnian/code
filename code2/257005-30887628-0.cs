    static void updateNumber(int userId, string oldNumber, string newNumber)
        {
            using (MyContext uow = new MyContext()) // Unit of Work
            {
                DbSet<User> repo = uow.Users; // Repository
                User user = repo.Find(userId); 
                Phone oldPhone = user.Phones.Where(x => x.Number.Trim() == oldNumber).SingleOrDefault();
                oldPhone.Number = newNumber;
                uow.SaveChanges();
            }
        }
