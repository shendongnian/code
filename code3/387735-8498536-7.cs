        public void Main()
        {
            MyContext db = new MyContext();
            Country Canada = Country.Find(db, "Canada");
            var users = from u in db.Users select u;
            foreach (User u in users)
            {
                u.Country = Canada;
            }
            db.SaveChanges();
        }
